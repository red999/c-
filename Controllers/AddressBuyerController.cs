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
    public class AddressBuyerController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AddressBuyer
        public ActionResult Index()
        {
            var addressBuyers = db.AddressBuyers.Include(a => a.AddressInfo).Include(a => a.Buyer);
            return View(addressBuyers.ToList());
        }

        // GET: AddressBuyer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressBuyer addressBuyer = db.AddressBuyers.Find(id);
            if (addressBuyer == null)
            {
                return HttpNotFound();
            }
            return View(addressBuyer);
        }

        // GET: AddressBuyer/Create
        public ActionResult Create()
        {
            ViewBag.AddressInfoID = new SelectList(db.AddressInfos, "ID", "homeName");
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "firmNameORsellerName");
            return View();
        }

        // POST: AddressBuyer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AddressInfoID,BuyerID")] AddressBuyer addressBuyer)
        {
            if (ModelState.IsValid)
            {
                db.AddressBuyers.Add(addressBuyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressInfoID = new SelectList(db.AddressInfos, "ID", "homeName", addressBuyer.AddressInfoID);
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "firmNameORsellerName", addressBuyer.BuyerID);
            return View(addressBuyer);
        }

        // GET: AddressBuyer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressBuyer addressBuyer = db.AddressBuyers.Find(id);
            if (addressBuyer == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressInfoID = new SelectList(db.AddressInfos, "ID", "homeName", addressBuyer.AddressInfoID);
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "firmNameORsellerName", addressBuyer.BuyerID);
            return View(addressBuyer);
        }

        // POST: AddressBuyer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AddressInfoID,BuyerID")] AddressBuyer addressBuyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressBuyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressInfoID = new SelectList(db.AddressInfos, "ID", "homeName", addressBuyer.AddressInfoID);
            ViewBag.BuyerID = new SelectList(db.Buyers, "ID", "firmNameORsellerName", addressBuyer.BuyerID);
            return View(addressBuyer);
        }

        // GET: AddressBuyer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressBuyer addressBuyer = db.AddressBuyers.Find(id);
            if (addressBuyer == null)
            {
                return HttpNotFound();
            }
            return View(addressBuyer);
        }

        // POST: AddressBuyer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressBuyer addressBuyer = db.AddressBuyers.Find(id);
            db.AddressBuyers.Remove(addressBuyer);
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
