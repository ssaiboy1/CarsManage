using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsManage.Models;

namespace CarsManage.Controllers
{
    public class Cars_BrandController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Cars_Brand
        public ActionResult Index()
        {
            return View(db.Cars_Brand.ToList());
        }

        // GET: Cars_Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Brand cars_Brand = db.Cars_Brand.Find(id);
            if (cars_Brand == null)
            {
                return HttpNotFound();
            }
            return View(cars_Brand);
        }

        // GET: Cars_Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars_Brand/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Brand_no,Brand_nm")] Cars_Brand cars_Brand)
        {
            if (ModelState.IsValid)
            {
                db.Cars_Brand.Add(cars_Brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars_Brand);
        }

        // GET: Cars_Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Brand cars_Brand = db.Cars_Brand.Find(id);
            if (cars_Brand == null)
            {
                return HttpNotFound();
            }
            return View(cars_Brand);
        }

        // POST: Cars_Brand/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Brand_no,Brand_nm")] Cars_Brand cars_Brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_Brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars_Brand);
        }

        // GET: Cars_Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Brand cars_Brand = db.Cars_Brand.Find(id);
            if (cars_Brand == null)
            {
                return HttpNotFound();
            }
            return View(cars_Brand);
        }

        // POST: Cars_Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_Brand cars_Brand = db.Cars_Brand.Find(id);
            db.Cars_Brand.Remove(cars_Brand);
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
