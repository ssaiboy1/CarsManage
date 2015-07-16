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
    public class Cars_InsuranceController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Cars_Insurance
        public ActionResult Index()
        {
            var cars_Insurance = db.Cars_Insurance.Include(c => c.Cars).Include(c => c.Insurance_Company);
            return View(cars_Insurance.ToList());
        }

        // GET: Cars_Insurance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Insurance cars_Insurance = db.Cars_Insurance.Find(id);
            if (cars_Insurance == null)
            {
                return HttpNotFound();
            }
            return View(cars_Insurance);
        }

        // GET: Cars_Insurance/Create
        public ActionResult Create()
        {
            ViewBag.Car_Uid = new SelectList(db.Cars, "Uid", "Center_no");
            ViewBag.Company_no = new SelectList(db.Insurance_Company, "Company_no", "Company_nm");
            return View();
        }

        // POST: Cars_Insurance/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Uid,Car_Uid,Company_no,Insurance_no,Card_no,Date_S,Date_E,Remark")] Cars_Insurance cars_Insurance)
        {
            if (ModelState.IsValid)
            {
                db.Cars_Insurance.Add(cars_Insurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Car_Uid = new SelectList(db.Cars, "Uid", "Center_no", cars_Insurance.Car_Uid);
            ViewBag.Company_no = new SelectList(db.Insurance_Company, "Company_no", "Company_nm", cars_Insurance.Company_no);
            return View(cars_Insurance);
        }

        // GET: Cars_Insurance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Insurance cars_Insurance = db.Cars_Insurance.Find(id);
            if (cars_Insurance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Car_Uid = new SelectList(db.Cars, "Uid", "Center_no", cars_Insurance.Car_Uid);
            ViewBag.Company_no = new SelectList(db.Insurance_Company, "Company_no", "Company_nm", cars_Insurance.Company_no);
            return View(cars_Insurance);
        }

        // POST: Cars_Insurance/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Uid,Car_Uid,Company_no,Insurance_no,Card_no,Date_S,Date_E,Remark")] Cars_Insurance cars_Insurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_Insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Car_Uid = new SelectList(db.Cars, "Uid", "Center_no", cars_Insurance.Car_Uid);
            ViewBag.Company_no = new SelectList(db.Insurance_Company, "Company_no", "Company_nm", cars_Insurance.Company_no);
            return View(cars_Insurance);
        }

        // GET: Cars_Insurance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Insurance cars_Insurance = db.Cars_Insurance.Find(id);
            if (cars_Insurance == null)
            {
                return HttpNotFound();
            }
            return View(cars_Insurance);
        }

        // POST: Cars_Insurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_Insurance cars_Insurance = db.Cars_Insurance.Find(id);
            db.Cars_Insurance.Remove(cars_Insurance);
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
