using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarsManage.Models;
using PagedList;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;


namespace CarsManage.Controllers
{
    public class CarsController : Controller
    {
        private HB_GlobalEntities db = new HB_GlobalEntities();
        private const int M_PageSize = 10;

        public ActionResult Index(string car_no, string center_no, string company_no, string brand_no,
                 string gas_no, string model, string tonnage, int page = 1)
        {

            ViewBag.center_no = new SelectList(db.Dlv_Center, "center_no", "center_nm");
            ViewBag.Select_center_no = center_no;
            ViewBag.company_no = new SelectList(db.Cars_Company, "Company_no", "Company_nm");
            ViewBag.Select_company_no = company_no;
            ViewBag.gas_no = new SelectList(db.Cars_Gas, "gas_no", "gas_nm");
            ViewBag.Select_gas_no = gas_no;
            ViewBag.brand_no = new SelectList(db.Cars_Brand, "brand_no", "brand_nm");
            ViewBag.Select_brand_no = brand_no;
            ViewBag.car_no = car_no;
            ViewBag.model = model;
            ViewBag.tonnage = tonnage;

            var carsdata = from s in db.Cars select s;
            if (!string.IsNullOrEmpty(car_no))
            {
                carsdata = carsdata.Where(c => c.Car_no.Contains(car_no));
            }
            if (!string.IsNullOrEmpty(center_no))
            {
                carsdata = carsdata.Where(x => x.Center_no == center_no);
            }
            if (!string.IsNullOrEmpty(company_no))
            {
                int s_company_no = Convert.ToInt32(company_no);
                carsdata = carsdata.Where(x => x.Company_no == s_company_no);
            }
            if (!string.IsNullOrEmpty(brand_no))
            {
                int s_brand_no = Convert.ToInt32(brand_no);
                carsdata = carsdata.Where(x => x.Brand_no == s_brand_no);
            }
            if (!string.IsNullOrEmpty(gas_no))
            {
                carsdata = carsdata.Where(x => x.Gas_no == gas_no);
            }
            if (!string.IsNullOrEmpty(model))
            {
                carsdata = carsdata.Where(x => x.Model == model);
            }

            var result = carsdata.OrderBy(d => d.Uid).ToPagedList(page, M_PageSize);
            return View(result);
        }

        private List<SelectListItem> GetSelectList(
            IEnumerable<string> source,
            string selectedItem)
        {
            var selectList = source.Select(item => new SelectListItem()
            {
                Text = item,
                Value = item,
                Selected = !string.IsNullOrWhiteSpace(selectedItem)
                           &&
                           item.Equals(selectedItem, StringComparison.OrdinalIgnoreCase)
            });
            return selectList.ToList();
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
            var cars1 = db.Cars.Include(c => c.Cars_Brand).Include(c => c.Cars_Company).Include(c => c.Cars_Gas).Include(c => c.Cars_State).Include(c => c.Dlv_Center);
            if (db.Cars.Any(x => x.Car_no == cars.Car_no))
            {
                ModelState.AddModelError("Car_no", "車號重複！");
                return View(cars1.ToList());
            }
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

        public ActionResult Copy(int? id)
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

        // POST: Cars/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Copy([Bind(Include = "Uid,Center_no,Company_no,Car_no,Brand_no,Model,Tonnage,Total_tonnage,AllLink_tonnage,Gas_no,Buy_date,Permit_date,Make_date,Cc,Body_no,Body_model,Engine_no,Seat,Color,Carstate_no")] Cars cars)
        {
            var cars1 = db.Cars.Include(c => c.Cars_Brand).Include(c => c.Cars_Company).Include(c => c.Cars_Gas).Include(c => c.Cars_State).Include(c => c.Dlv_Center);
            if (db.Cars.Any(x => x.Car_no == cars.Car_no))
            {
                ModelState.AddModelError("Car_no", "車號重複！");
                return View(cars1.ToList());
            }
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

        public ActionResult SreachCars(string car_no, string center_no, string brand_no,
                         string gas_no, string model, string tonnage, int page = 1, int pageSize = 10)
        {
            ViewBag.center_no = new SelectList(db.Dlv_Center, "center_no", "center_nm");
            ViewBag.gas_no = new SelectList(db.Cars_Gas, "gas_no", "gas_nm");
            ViewBag.brand_no = new SelectList(db.Cars_Brand, "brand_no", "brand_nm");
            var carsdata = from s in db.Cars select s;
            if (!string.IsNullOrEmpty(car_no))
            {
                carsdata = carsdata.Where(c => c.Car_no.Contains(car_no));
            }
            if (!string.IsNullOrEmpty(center_no))
            {
                carsdata = carsdata.Where(x => x.Center_no == center_no);
            }
            if (!string.IsNullOrEmpty(brand_no))
            {
                int s_brand_no = Convert.ToInt32(brand_no);
                carsdata = carsdata.Where(x => x.Brand_no == s_brand_no);
            }
            if (!string.IsNullOrEmpty(gas_no))
            {
                carsdata = carsdata.Where(x => x.Gas_no == gas_no);
            }
            if (!string.IsNullOrEmpty(model))
            {
                carsdata = carsdata.Where(x => x.Model == model);
            }
            //var result = model.OrderBy(d => d.CreateDate).ToPagedList(page, pageSize);
            var result = carsdata.OrderBy(d => d.Uid).ToPagedList(page, pageSize);
            return View(result);
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
