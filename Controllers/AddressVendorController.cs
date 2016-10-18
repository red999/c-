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
    public class AddressVendorController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AddressVendor
        public ActionResult Index()
        {
            var addressVendors = db.AddressVendors.Include(a => a.Vendor);
            return View(addressVendors.ToList());
        }

        // GET: AddressVendor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressVendor addressVendor = db.AddressVendors.Find(id);
            if (addressVendor == null)
            {
                return HttpNotFound();
            }
            return View(addressVendor);
        }

        // GET: AddressVendor/Create
        public ActionResult Create()
        {
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName");
            return View();
        }

        // POST: AddressVendor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VendorID")] AddressVendor addressVendor)
        {
            if (ModelState.IsValid)
            {
                db.AddressVendors.Add(addressVendor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName", addressVendor.VendorID);
            return View(addressVendor);
        }

        // GET: AddressVendor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressVendor addressVendor = db.AddressVendors.Find(id);
            if (addressVendor == null)
            {
                return HttpNotFound();
            }
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName", addressVendor.VendorID);
            return View(addressVendor);
        }

        // POST: AddressVendor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VendorID")] AddressVendor addressVendor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressVendor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "firmNameORsellerName", addressVendor.VendorID);
            return View(addressVendor);
        }

        // GET: AddressVendor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressVendor addressVendor = db.AddressVendors.Find(id);
            if (addressVendor == null)
            {
                return HttpNotFound();
            }
            return View(addressVendor);
        }

        // POST: AddressVendor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressVendor addressVendor = db.AddressVendors.Find(id);
            db.AddressVendors.Remove(addressVendor);
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
