using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace limantakip4.Controllers
{
    public class CerezController : Controller
    {
        // GET: Cerez
        public ActionResult OnlineUyeSayisi()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }
    }
}