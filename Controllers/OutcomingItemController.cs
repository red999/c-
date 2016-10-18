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
    public class OutcomingItemController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: OutcomingItem
        public ActionResult Index()
        {
            var outcomingItem = db.OutcomingItem.Include(o => o.ItemCard);
            return View(outcomingItem.ToList());
        }

        // GET: OutcomingItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomingItem outcomingItem = db.OutcomingItem.Find(id);
            if (outcomingItem == null)
            {
                return HttpNotFound();
            }
            return View(outcomingItem);
        }

        // GET: OutcomingItem/Create
        public ActionResult Create()
        {
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name");
            return View();
        }

        // POST: OutcomingItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,date,quantity,ItemCardID")] OutcomingItem outcomingItem)
        {
            if (ModelState.IsValid)
            {
                db.OutcomingItem.Add(outcomingItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", outcomingItem.ItemCardID);
            return View(outcomingItem);
        }

        // GET: OutcomingItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomingItem outcomingItem = db.OutcomingItem.Find(id);
            if (outcomingItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", outcomingItem.ItemCardID);
            return View(outcomingItem);
        }

        // POST: OutcomingItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,date,quantity,ItemCardID")] OutcomingItem outcomingItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(outcomingItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", outcomingItem.ItemCardID);
            return View(outcomingItem);
        }

        // GET: OutcomingItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OutcomingItem outcomingItem = db.OutcomingItem.Find(id);
            if (outcomingItem == null)
            {
                return HttpNotFound();
            }
            return View(outcomingItem);
        }

        // POST: OutcomingItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OutcomingItem outcomingItem = db.OutcomingItem.Find(id);
            db.OutcomingItem.Remove(outcomingItem);
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
