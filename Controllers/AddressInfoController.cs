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
    public class AddressInfoController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AddressInfo
        public ActionResult Index()
        {
            var addressInfos = db.AddressInfos.Include(a => a.City).Include(a => a.Country).Include(a => a.Street);
            return View(addressInfos.ToList());
        }

        // GET: AddressInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressInfo addressInfo = db.AddressInfos.Find(id);
            if (addressInfo == null)
            {
                return HttpNotFound();
            }
            return View(addressInfo);
        }

        // GET: AddressInfo/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Citites, "ID", "name");
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "name");
            ViewBag.StreetID = new SelectList(db.Streets, "ID", "name");
            return View();
        }

        // POST: AddressInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,homeName,CountryID,CityID,StreetID")] AddressInfo addressInfo)
        {
            if (ModelState.IsValid)
            {
                db.AddressInfos.Add(addressInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Citites, "ID", "name", addressInfo.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "name", addressInfo.CountryID);
            ViewBag.StreetID = new SelectList(db.Streets, "ID", "name", addressInfo.StreetID);
            return View(addressInfo);
        }

        // GET: AddressInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressInfo addressInfo = db.AddressInfos.Find(id);
            if (addressInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Citites, "ID", "name", addressInfo.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "name", addressInfo.CountryID);
            ViewBag.StreetID = new SelectList(db.Streets, "ID", "name", addressInfo.StreetID);
            return View(addressInfo);
        }

        // POST: AddressInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,homeName,CountryID,CityID,StreetID")] AddressInfo addressInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Citites, "ID", "name", addressInfo.CityID);
            ViewBag.CountryID = new SelectList(db.Countries, "ID", "name", addressInfo.CountryID);
            ViewBag.StreetID = new SelectList(db.Streets, "ID", "name", addressInfo.StreetID);
            return View(addressInfo);
        }

        // GET: AddressInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressInfo addressInfo = db.AddressInfos.Find(id);
            if (addressInfo == null)
            {
                return HttpNotFound();
            }
            return View(addressInfo);
        }

        // POST: AddressInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressInfo addressInfo = db.AddressInfos.Find(id);
            db.AddressInfos.Remove(addressInfo);
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
