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
    public class ChangeItemInfoController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: ChangeItemInfo
        public ActionResult Index()
        {
            var changeItemInfos = db.ChangeItemInfos.Include(c => c.ItemCard);
            return View(changeItemInfos.ToList());
        }

        // GET: ChangeItemInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeItemInfo changeItemInfo = db.ChangeItemInfos.Find(id);
            if (changeItemInfo == null)
            {
                return HttpNotFound();
            }
            return View(changeItemInfo);
        }

        // GET: ChangeItemInfo/Create
        public ActionResult Create()
        {
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name");
            return View();
        }

        // POST: ChangeItemInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,price,date,ItemCardID")] ChangeItemInfo changeItemInfo)
        {
            if (ModelState.IsValid)
            {
                db.ChangeItemInfos.Add(changeItemInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", changeItemInfo.ItemCardID);
            return View(changeItemInfo);
        }

        // GET: ChangeItemInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeItemInfo changeItemInfo = db.ChangeItemInfos.Find(id);
            if (changeItemInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", changeItemInfo.ItemCardID);
            return View(changeItemInfo);
        }

        // POST: ChangeItemInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,price,date,ItemCardID")] ChangeItemInfo changeItemInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(changeItemInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", changeItemInfo.ItemCardID);
            return View(changeItemInfo);
        }

        // GET: ChangeItemInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChangeItemInfo changeItemInfo = db.ChangeItemInfos.Find(id);
            if (changeItemInfo == null)
            {
                return HttpNotFound();
            }
            return View(changeItemInfo);
        }

        // POST: ChangeItemInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChangeItemInfo changeItemInfo = db.ChangeItemInfos.Find(id);
            db.ChangeItemInfos.Remove(changeItemInfo);
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
