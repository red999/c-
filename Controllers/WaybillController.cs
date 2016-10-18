using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopV2.DAL;
using ShopV2.Models;

namespace ShopV2.Controllers
{
    public class WaybillController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: Waybill
        public ActionResult Index()
        {
            var waybills = db.Waybills.Include(w => w.Firm).Include(w => w.ItemCard).Include(w => w.PackageType).Include(w => w.Vendor);
            return View(waybills.ToList());
        }

        // GET: Waybill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waybill waybill = db.Waybills.Find(id);
            if (waybill == null)
            {
                return HttpNotFound();
            }
            return View(waybill);
        }

        // GET: Waybill/Create
        public ActionResult Create()
        {
            ViewBag.FirmID = new SelectList(db.Firms, "ID", "name");
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name");
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName");
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName");
            return View();
        }

        // POST: Waybill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,number,VendorID,FirmID,ItemCardID,ChangeInfoID,date,PackageTypeID,sum")] Waybill waybill)
        {
            if (ModelState.IsValid)
            {
                db.Waybills.Add(waybill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FirmID = new SelectList(db.Firms, "ID", "name", waybill.FirmID);
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", waybill.ItemCardID);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName", waybill.PackageTypeID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName", waybill.VendorID);
            return View(waybill);
        }

        // GET: Waybill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waybill waybill = db.Waybills.Find(id);
            if (waybill == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmID = new SelectList(db.Firms, "ID", "name", waybill.FirmID);
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", waybill.ItemCardID);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName", waybill.PackageTypeID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName", waybill.VendorID);
            return View(waybill);
        }

        // POST: Waybill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,number,VendorID,FirmID,ItemCardID,ChangeInfoID,date,PackageTypeID,sum")] Waybill waybill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(waybill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmID = new SelectList(db.Firms, "ID", "name", waybill.FirmID);
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", waybill.ItemCardID);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName", waybill.PackageTypeID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName", waybill.VendorID);
            return View(waybill);
        }

        // GET: Waybill/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Waybill waybill = db.Waybills.Find(id);
            if (waybill == null)
            {
                return HttpNotFound();
            }
            return View(waybill);
        }

        // POST: Waybill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Waybill waybill = db.Waybills.Find(id);
            db.Waybills.Remove(waybill);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
