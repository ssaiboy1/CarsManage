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
    public class CarsController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Cars_Brand).Include(c => c.Cars_Company).Include(c => c.Cars_Gas).Include(c => c.Cars_State).Include(c => c.Dlv_Center);
            return View(cars.ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.Brand_no = new SelectList(db.Cars_Brand, "Brand_no", "Brand_nm");
            ViewBag.Company_no = new SelectList(db.Cars_Company, "Company_no", "Company_nm");
            ViewBag.Gas_no = new SelectList(db.Cars_Gas, "Gas_no", "Gas_nm");
            ViewBag.Carstate_no = new SelectList(db.Cars_State, "Carstate_no", "Carstate_nm");
            ViewBag.Center_no = new SelectList(db.Dlv_Center, "Center_no", "Center_nm");
            return View();
        }

        // POST: Cars/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Uid,Center_no,Company_no,Car_no,Brand_no,Model,Tonnage,Total_tonnage,AllLink_tonnage,Gas_no,Buy_date,Permit_date,Make_date,Cc,Body_no,Body_model,Engine_no,Seat,Color,Carstate_no")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(cars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Brand_no = new SelectList(db.Cars_Brand, "Brand_no", "Brand_nm", cars.Brand_no);
            ViewBag.Company_no = new SelectList(db.Cars_Company, "Company_no", "Company_nm", cars.Company_no);
            ViewBag.Gas_no = new SelectList(db.Cars_Gas, "Gas_no", "Gas_nm", cars.Gas_no);
            ViewBag.Carstate_no = new SelectList(db.Cars_State, "Carstate_no", "Carstate_nm", cars.Carstate_no);
            ViewBag.Center_no = new SelectList(db.Dlv_Center, "Center_no", "Center_nm", cars.Center_no);
            return View(cars);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand_no = new SelectList(db.Cars_Brand, "Brand_no", "Brand_nm", cars.Brand_no);
            ViewBag.Company_no = new SelectList(db.Cars_Company, "Company_no", "Company_nm", cars.Company_no);
            ViewBag.Gas_no = new SelectList(db.Cars_Gas, "Gas_no", "Gas_nm", cars.Gas_no);
            ViewBag.Carstate_no = new SelectList(db.Cars_State, "Carstate_no", "Carstate_nm", cars.Carstate_no);
            ViewBag.Center_no = new SelectList(db.Dlv_Center, "Center_no", "Center_nm", cars.Center_no);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Uid,Center_no,Company_no,Car_no,Brand_no,Model,Tonnage,Total_tonnage,AllLink_tonnage,Gas_no,Buy_date,Permit_date,Make_date,Cc,Body_no,Body_model,Engine_no,Seat,Color,Carstate_no")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Brand_no = new SelectList(db.Cars_Brand, "Brand_no", "Brand_nm", cars.Brand_no);
            ViewBag.Company_no = new SelectList(db.Cars_Company, "Company_no", "Company_nm", cars.Company_no);
            ViewBag.Gas_no = new SelectList(db.Cars_Gas, "Gas_no", "Gas_nm", cars.Gas_no);
            ViewBag.Carstate_no = new SelectList(db.Cars_State, "Carstate_no", "Carstate_nm", cars.Carstate_no);
            ViewBag.Center_no = new SelectList(db.Dlv_Center, "Center_no", "Center_nm", cars.Center_no);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars cars = db.Cars.Find(id);
            if (cars == null)
            {
                return HttpNotFound();
            }
            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars cars = db.Cars.Find(id);
            db.Cars.Remove(cars);
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
