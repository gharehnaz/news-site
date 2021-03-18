using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.Web.Areas.AdminHome.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome/AdminHome
        public ActionResult Index()
        {
            return View();
        }
    }
}