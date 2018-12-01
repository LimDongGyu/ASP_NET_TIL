using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TermHomePage.Controllers
{
    public class TermHomeController : Controller
    {
        // GET: TermHome
        public ActionResult Index()
        {
            return View();
        }
    }
}