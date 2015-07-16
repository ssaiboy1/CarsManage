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
    public class Dlv_CenterController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Dlv_Center
        public ActionResult Index()
        {
            return View(db.Dlv_Center.ToList());
        }

        // GET: Dlv_Center/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dlv_Center dlv_Center = db.Dlv_Center.Find(id);
            if (dlv_Center == null)
            {
                return HttpNotFound();
            }
            return View(dlv_Center);
        }

        // GET: Dlv_Center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dlv_Center/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Center_no,Center_nm,Addr,Tel,Fax,Email,Contact,Dsp_sw")] Dlv_Center dlv_Center)
        {
            if (ModelState.IsValid)
            {
                db.Dlv_Center.Add(dlv_Center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dlv_Center);
        }

        // GET: Dlv_Center/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dlv_Center dlv_Center = db.Dlv_Center.Find(id);
            if (dlv_Center == null)
            {
                return HttpNotFound();
            }
            return View(dlv_Center);
        }

        // POST: Dlv_Center/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Center_no,Center_nm,Addr,Tel,Fax,Email,Contact,Dsp_sw")] Dlv_Center dlv_Center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dlv_Center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dlv_Center);
        }

        // GET: Dlv_Center/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dlv_Center dlv_Center = db.Dlv_Center.Find(id);
            if (dlv_Center == null)
            {
                return HttpNotFound();
            }
            return View(dlv_Center);
        }

        // POST: Dlv_Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dlv_Center dlv_Center = db.Dlv_Center.Find(id);
            db.Dlv_Center.Remove(dlv_Center);
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
