﻿using System;
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
    public class Insurance_CompanyController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Insurance_Company
        public ActionResult Index()
        {
            return View(db.Insurance_Company.ToList());
        }

        // GET: Insurance_Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance_Company insurance_Company = db.Insurance_Company.Find(id);
            if (insurance_Company == null)
            {
                return HttpNotFound();
            }
            return View(insurance_Company);
        }

        // GET: Insurance_Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurance_Company/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Company_no,Company_nm")] Insurance_Company insurance_Company)
        {
            if (ModelState.IsValid)
            {
                db.Insurance_Company.Add(insurance_Company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insurance_Company);
        }

        // GET: Insurance_Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance_Company insurance_Company = db.Insurance_Company.Find(id);
            if (insurance_Company == null)
            {
                return HttpNotFound();
            }
            return View(insurance_Company);
        }

        // POST: Insurance_Company/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Company_no,Company_nm")] Insurance_Company insurance_Company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insurance_Company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insurance_Company);
        }

        // GET: Insurance_Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurance_Company insurance_Company = db.Insurance_Company.Find(id);
            if (insurance_Company == null)
            {
                return HttpNotFound();
            }
            return View(insurance_Company);
        }

        // POST: Insurance_Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurance_Company insurance_Company = db.Insurance_Company.Find(id);
            db.Insurance_Company.Remove(insurance_Company);
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
