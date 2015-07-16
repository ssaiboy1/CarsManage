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
    public class InsurancesController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Insurances
        public ActionResult Index()
        {
            var insurance = db.Insurance.Include(i => i.Cars_Insurance);
            return View(insurance.ToList());
        }

        // GET: Insurances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurance.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // GET: Insurances/Create
        public ActionResult Create()
        {
            ViewBag.Insurance_Uid = new SelectList(db.Cars_Insurance, "Uid", "Insurance_no");
            return View();
        }

        // POST: Insurances/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Uid,Insurance_Uid,Insurance_no,Insurance_nm,Insurance_Money,Self_Money,Pay_Money,Remark")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                db.Insurance.Add(insurance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Insurance_Uid = new SelectList(db.Cars_Insurance, "Uid", "Insurance_no", insurance.Insurance_Uid);
            return View(insurance);
        }

        // GET: Insurances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurance.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            ViewBag.Insurance_Uid = new SelectList(db.Cars_Insurance, "Uid", "Insurance_no", insurance.Insurance_Uid);
            return View(insurance);
        }

        // POST: Insurances/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Uid,Insurance_Uid,Insurance_no,Insurance_nm,Insurance_Money,Self_Money,Pay_Money,Remark")] Insurance insurance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Insurance_Uid = new SelectList(db.Cars_Insurance, "Uid", "Insurance_no", insurance.Insurance_Uid);
            return View(insurance);
        }

        // GET: Insurances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance insurance = db.Insurance.Find(id);
            if (insurance == null)
            {
                return HttpNotFound();
            }
            return View(insurance);
        }

        // POST: Insurances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurance insurance = db.Insurance.Find(id);
            db.Insurance.Remove(insurance);
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
