using KATPHONE.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KATPHONE.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private DIENTHOAIDBCONTEXT db= new DIENTHOAIDBCONTEXT();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetStatistical(string fromDate, string toDate)
        {
            var query = from o in db.HOADONs
                        join od in db.CTHDs
                        on o.MAHD equals od.MAHD
                        join p in db.DIENTHOAIs
                        on od.MASP equals p.MASP
                        select new
                        {
                            o.NGAYLAP,od.SOLUONG,p.GIABAN,p.GIANHAP
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.NGAYLAP >= startDate);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.NGAYLAP < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.NGAYLAP)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.SOLUONG * y.GIANHAP),
                TotalSell = x.Sum(y => y.SOLUONG * y.GIABAN),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });
            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}