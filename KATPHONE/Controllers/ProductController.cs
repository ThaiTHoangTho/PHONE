using KATPHONE.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KATPHONE.Controllers
{
    public class ProductController : Controller
    {
        private DIENTHOAIDBCONTEXT db = new DIENTHOAIDBCONTEXT();
        // GET: Products
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<DIENTHOAI> items = db.DIENTHOAIs.OrderByDescending(x => x.GIABAN);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.TENSP.ToLower().Trim().Contains(Searchtext.ToLower().Trim()) || x.TENSP.Contains(Searchtext.ToLower().Trim()));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult ProductCategory(int id)
        {
            var item = db.DIENTHOAIs.ToList();
            if (id > 0)
            {
                item = item.Where(x => x.MANSX == id).ToList();
            }
            var cate = db.NHASANXUATs.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.TENNSX;
            }
            ViewBag.CateId = id;
            return View(item);
        }
        public ActionResult Detail(int id)
        {
            var item = db.DIENTHOAIs.Find(id);
            return View(item);
        }
        public ActionResult Partial_ItemsbyCategoryId()
        {
            var items = db.DIENTHOAIs.ToList();
            return PartialView("_Partial_ItemsbyCategoryId", items);
        }

    }
}