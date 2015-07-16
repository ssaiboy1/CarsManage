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
    public class Cars_StateController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();

        // GET: Cars_State
        public ActionResult Index()
        {
            return View(db.Cars_State.ToList());
        }

        // GET: Cars_State/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_State cars_State = db.Cars_State.Find(id);
            if (cars_State == null)
            {
                return HttpNotFound();
            }
            return View(cars_State);
        }

        // GET: Cars_State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cars_State/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carstate_no,Carstate_nm")] Cars_State cars_State)
        {
            if (ModelState.IsValid)
            {
                db.Cars_State.Add(cars_State);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars_State);
        }

        // GET: Cars_State/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_State cars_State = db.Cars_State.Find(id);
            if (cars_State == null)
            {
                return HttpNotFound();
            }
            return View(cars_State);
        }

        // POST: Cars_State/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carstate_no,Carstate_nm")] Cars_State cars_State)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_State).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars_State);
        }

        // GET: Cars_State/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_State cars_State = db.Cars_State.Find(id);
            if (cars_State == null)
            {
                return HttpNotFound();
            }
            return View(cars_State);
        }

        // POST: Cars_State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_State cars_State = db.Cars_State.Find(id);
            db.Cars_State.Remove(cars_State);
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
