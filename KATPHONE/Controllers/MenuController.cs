using KATPHONE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KATPHONE.Controllers
{
    public class MenuController : Controller
    {

        private DIENTHOAIDBCONTEXT db = new DIENTHOAIDBCONTEXT();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuProductCategory()
        {
            var items = db.NHASANXUATs.ToList();
            return PartialView("_MenuProductCategory", items);
        }

        public ActionResult MenuArrivals()
        {
            var a = db.NHASANXUATs.ToList();
            return PartialView("_MenuArrivals", a);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.NHASANXUATs;
            return PartialView("_MenuLeft", items);
        }
    }
}