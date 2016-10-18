using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopV2.DAL;
using ShopV2.ViewModels;
using ShopV2.Models;
using System.Data.Entity.Infrastructure;

namespace ShopV2.Controllers
{
    public class ItemCardCreateController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: ItemCardCreate
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            PopulateVendorDropDownList();
            PopulateDepartmentsDropDownList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(ItemCardCreate viewModel)
        {
            try
            {
                var itemCard = new ItemCard()
                {
                    name = viewModel.name,
                    measureType = viewModel.measureType,
                    nomenclatureNumber = viewModel.nomenclatureNumber,
                    articularNumber = viewModel.articularNumber,
                    barCode = viewModel.barCode

                };
                db.ItemCards.Add(itemCard);
                db.SaveChanges();
                int lastItemID = itemCard.ID;

                //int lastid = db.ItemCards.Max(item => item.ID);
                var packageInfo = new PackageInfo()
                {
                    ItemCardID = lastItemID, 
                    count = viewModel.count,
                    PackageTypeID = viewModel.PackageTypeID,
                    //itemCardID ?!
                };
                db.PackageInfos.Add(packageInfo);
                db.SaveChanges();

                var changeiteminfo = new ChangeItemInfo()
                {
                    ItemCardID = lastItemID,
                    price = viewModel.price,
                    date = viewModel.date
                };
                db.ChangeItemInfos.Add(changeiteminfo);
                db.SaveChanges();
                
                var incomings = new IncomingItem()
                {
                    date = viewModel.date,
                    quantity = viewModel.count,
                    ItemCardID = lastItemID,
                    VendorID = viewModel.VendorID
                };
                db.IncomingItems.Add(incomings);
                
                
                
                db.SaveChanges();
            }

            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            PopulateVendorDropDownList(viewModel.VendorID);
            PopulateDepartmentsDropDownList(viewModel.PackageTypeID);

            return View();
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = from d in db.PackageTypes
                                   orderby d.typeName
                                   select d;
            ViewBag.PackageTypeID = new SelectList(departmentsQuery, "PackageTypeID", "typeName", selectedDepartment);
        }

        private void PopulateVendorDropDownList(object selectedVendor = null)
        {
            var vendorsQuery = from dd in db.Vendors
                                   orderby dd.ID
                                   select dd;
            ViewBag.VendorID = new SelectList(vendorsQuery, "ID", "firmNameORsellerName", selectedVendor);
        }


    }
}