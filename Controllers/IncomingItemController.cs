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
    public class IncomingItemController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: IncomingItem
        public ActionResult Index()
        {
            var incomingItems = db.IncomingItems.Include(i => i.ItemCard);
            return View(incomingItems.ToList());
        }

        // GET: IncomingItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItem incomingItem = db.IncomingItems.Find(id);
            if (incomingItem == null)
            {
                return HttpNotFound();
            }
            return View(incomingItem);
        }

        // GET: IncomingItem/Create
        public ActionResult Create()
        {
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name");
            return View();
        }

        // POST: IncomingItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,date,quantity,ItemCardID")] IncomingItem incomingItem)
        {
            if (ModelState.IsValid)
            {
                db.IncomingItems.Add(incomingItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", incomingItem.ItemCardID);
            return View(incomingItem);
        }

        // GET: IncomingItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItem incomingItem = db.IncomingItems.Find(id);
            if (incomingItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", incomingItem.ItemCardID);
            return View(incomingItem);
        }

        // POST: IncomingItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,date,quantity,ItemCardID")] IncomingItem incomingItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomingItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", incomingItem.ItemCardID);
            return View(incomingItem);
        }

        // GET: IncomingItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomingItem incomingItem = db.IncomingItems.Find(id);
            if (incomingItem == null)
            {
                return HttpNotFound();
            }
            return View(incomingItem);
        }

        // POST: IncomingItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncomingItem incomingItem = db.IncomingItems.Find(id);
            db.IncomingItems.Remove(incomingItem);
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
