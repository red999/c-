using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopV2.DAL;
using ShopV2.ViewModels;

namespace ShopV2.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<ItemCardGroup> data = from ItemCards in db.ItemCards group ItemCards by ItemCards.barCode into barCodeGroup
                                                   select new ItemCardGroup()
                                                   {
                                                       barCode = barCodeGroup.Key,
                                                       itemCardsCount = barCodeGroup.Count()
                                                   };
            return View(data.ToList());
            //ViewBag.Message = "Your application description page.";

            //return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}