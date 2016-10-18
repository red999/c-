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
    public class PackageInfoController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: PackageInfo
        public ActionResult Index()
        {
            var packageInfos = db.PackageInfos.Include(p => p.ItemCard).Include(p => p.PackageType);
            return View(packageInfos.ToList());
        }

        // GET: PackageInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageInfo packageInfo = db.PackageInfos.Find(id);
            if (packageInfo == null)
            {
                return HttpNotFound();
            }
            return View(packageInfo);
        }

        // GET: PackageInfo/Create
        public ActionResult Create()
        {
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name");
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName");
            return View();
        }

        // POST: PackageInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackageInfoID,count,PackageTypeID,ItemCardID")] PackageInfo packageInfo)
        {
            if (ModelState.IsValid)
            {
                db.PackageInfos.Add(packageInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", packageInfo.ItemCardID);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName", packageInfo.PackageTypeID);
            return View(packageInfo);
        }

        // GET: PackageInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageInfo packageInfo = db.PackageInfos.Find(id);
            if (packageInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", packageInfo.ItemCardID);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName", packageInfo.PackageTypeID);
            return View(packageInfo);
        }

        // POST: PackageInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackageInfoID,count,PackageTypeID,ItemCardID")] PackageInfo packageInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packageInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemCardID = new SelectList(db.ItemCards, "ID", "name", packageInfo.ItemCardID);
            ViewBag.PackageTypeID = new SelectList(db.PackageTypes, "PackageTypeID", "typeName", packageInfo.PackageTypeID);
            return View(packageInfo);
        }

        // GET: PackageInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackageInfo packageInfo = db.PackageInfos.Find(id);
            if (packageInfo == null)
            {
                return HttpNotFound();
            }
            return View(packageInfo);
        }

        // POST: PackageInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PackageInfo packageInfo = db.PackageInfos.Find(id);
            db.PackageInfos.Remove(packageInfo);
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
