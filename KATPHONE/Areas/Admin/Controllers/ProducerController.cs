using KATPHONE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KATPHONE.Areas.Admin.Controllers
{
    public class ProducerController : Controller
    {
        private DIENTHOAIDBCONTEXT db = new DIENTHOAIDBCONTEXT();
        // GET: Admin/Producer
        public ActionResult Index()
        {
            var item = db.NHASANXUATs;
            return View(item);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NHASANXUAT n)
        {
            if (ModelState.IsValid)
            {
                db.NHASANXUATs.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var item = db.NHASANXUATs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NHASANXUAT model)
        {
            if (ModelState.IsValid)
            {
                db.NHASANXUATs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.NHASANXUATs.Find(id);
            if (item != null)
            {
                db.NHASANXUATs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}