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
using PagedList;

namespace ShopV2.Controllers
{
    public class ItemCardController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: ItemCard
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.nameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.measureSortParm = sortOrder == "measureType" ? "measureType_desc" : "measureType";
            ViewBag.nomnumSortParm = sortOrder == "nomenclatureNumber" ? "nomenclatureNumber_desc" : "nomenclatureNumber";
            ViewBag.articulnumSortParm = sortOrder == "articularNumber" ? "articularNumber_desc" : "articularNumber";
            ViewBag.barcodeSortParm = sortOrder == "barCode" ? "barCode_desc" : "barCode";

            var itemcards = from s in db.ItemCards select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                itemcards = itemcards.Where(i => i.name.Contains(searchString));
            }
            
            switch (sortOrder)
            {
                case "name_desc":
                    itemcards = itemcards.OrderByDescending(s => s.name);
                    break;
                case "measureType":
                    itemcards = itemcards.OrderBy(s => s.measureType);
                    break;
                case "measureType_desc":
                    itemcards = itemcards.OrderByDescending(s => s.measureType);
                    break;
                case "nomenclatureNumber":
                    itemcards = itemcards.OrderBy(n => n.nomenclatureNumber);
                    break;
                case "nomenclatureNumber_desc":
                    itemcards = itemcards.OrderByDescending(nd => nd.nomenclatureNumber);
                    break;
                case "articularNumber":
                    itemcards = itemcards.OrderBy(an => an.articularNumber);
                    break;
                case "articularNumber_desc":
                    itemcards = itemcards.OrderByDescending(and => and.articularNumber);
                    break;
                case "barCode":
                    itemcards = itemcards.OrderBy(bc => bc.barCode);
                    break;
                case "barCode_desc":
                    itemcards = itemcards.OrderByDescending(bcd => bcd.barCode);
                    break;
                default:
                    itemcards = itemcards.OrderBy(s => s.name);
                    break;
            }

            return View(itemcards.ToList());
        }

        // GET: ItemCard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCard itemCard = db.ItemCards.Find(id);
            if (itemCard == null)
            {
                return HttpNotFound();
            }
            return View(itemCard);
        }

        // GET: ItemCard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemCard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,measureType,nomenclatureNumber,articularNumber,barCode")] ItemCard itemCard)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ItemCards.Add(itemCard);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(itemCard);
        }

        // GET: ItemCard/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCard itemCard = db.ItemCards.Find(id);
            if (itemCard == null)
            {
                return HttpNotFound();
            }
            return View(itemCard);
        }

        // POST: ItemCard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,measureType,nomenclatureNumber,articularNumber,barCode")] ItemCard itemCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemCard);
        }

        // GET: ItemCard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemCard itemCard = db.ItemCards.Find(id);
            if (itemCard == null)
            {
                return HttpNotFound();
            }
            return View(itemCard);
        }

        // POST: ItemCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemCard itemCard = db.ItemCards.Find(id);
            db.ItemCards.Remove(itemCard);
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
