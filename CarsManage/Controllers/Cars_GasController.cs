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
    public class Cars_GasController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Cars_Gas
        public ActionResult Index()
        {
            return View(db.Cars_Gas.ToList());
        }

        // GET: Cars_Gas/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Gas cars_Gas = db.Cars_Gas.Find(id);
            if (cars_Gas == null)
            {
                return HttpNotFound();
            }
            return View(cars_Gas);
        }

        // GET: Cars_Gas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars_Gas/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gas_no,Gas_nm")] Cars_Gas cars_Gas)
        {
            if (ModelState.IsValid)
            {
                db.Cars_Gas.Add(cars_Gas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars_Gas);
        }

        // GET: Cars_Gas/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Gas cars_Gas = db.Cars_Gas.Find(id);
            if (cars_Gas == null)
            {
                return HttpNotFound();
            }
            return View(cars_Gas);
        }

        // POST: Cars_Gas/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gas_no,Gas_nm")] Cars_Gas cars_Gas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_Gas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars_Gas);
        }

        // GET: Cars_Gas/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Gas cars_Gas = db.Cars_Gas.Find(id);
            if (cars_Gas == null)
            {
                return HttpNotFound();
            }
            return View(cars_Gas);
        }

        // POST: Cars_Gas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cars_Gas cars_Gas = db.Cars_Gas.Find(id);
            db.Cars_Gas.Remove(cars_Gas);
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
