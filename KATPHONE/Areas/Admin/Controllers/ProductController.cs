using KATPHONE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace KATPHONE.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private DIENTHOAIDBCONTEXT db= new DIENTHOAIDBCONTEXT();
        // GET: Admin/Product
        public ActionResult Index(int? page)
        {
            IEnumerable<DIENTHOAI> items = db.DIENTHOAIs.OrderByDescending(x => x.MASP);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            ViewBag.NHASANXUAT = new SelectList(db.NHASANXUATs.ToList(), "MANSX", "TENNSX");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(DIENTHOAI model)
        {
            if (ModelState.IsValid)
            {

                ViewBag.NHASANXUAT = new SelectList(db.NHASANXUATs.ToList(), "MANSX", "TENNSX");
                db.DIENTHOAIs.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);

        }
        public ActionResult Edit(int id)
        {
            ViewBag.NHASANXUAT = new SelectList(db.NHASANXUATs.ToList(), "MANSX", "TENNSX");
            var item = db.DIENTHOAIs.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DIENTHOAI model)
        {
            if (ModelState.IsValid)
            {
                db.DIENTHOAIs.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.DIENTHOAIs.Find(id);
            if (item != null)
            {
                db.DIENTHOAIs.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

       
    }
}