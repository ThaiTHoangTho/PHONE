using KATPHONE.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KATPHONE.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private DIENTHOAIDBCONTEXT db= new DIENTHOAIDBCONTEXT();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var query = from o in db.HOADONs
                        join od in db.CTHDs
                        on o.MAHD equals od.MAHD
                        join p in db.KHACHHANGs
                        on o.MAKH equals p.MAKH
                        select new
                        {
                            ngaylap = o.NGAYLAP,
                            tenkh = p.TENKH,
                            sdt = p.SDT
                        };
            var items = db.HOADONs.OrderByDescending(x => x.NGAYLAP).ToList();
            if (items == null)
            {
                page = 1;
            }
            var pageIndex = page ?? 1;
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageIndex;
            return View(items.ToPagedList(pageIndex, pageSize));
        }
        public ActionResult Detail(int id)
        {
            var item = db.HOADONs.Find(id);
            return View(item);

        }
        public ActionResult Partial_ProductDetail(int id)
        {
            var items = db.CTHDs.Where(x => x.MAHD == id).ToList();
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult UpdateStatus(int id, int status)
        {
            var item = db.HOADONs.Find(id);
            if (item != null)
            {
                db.HOADONs.Attach(item);
                //item. = status;
                //db.Entry(item).Property(x => x.TypePayment).IsModified = true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
    }
}