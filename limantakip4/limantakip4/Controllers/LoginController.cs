using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using limantakip4.Models;

namespace limantakip4.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(uye objuser)
        {
            if (ModelState.IsValid)
            {using(takipsistemiEntities db=new takipsistemiEntities())
                {
                    var obj = db.uye.Where(a => a.kullanıcıadı.Equals(objuser.kullanıcıadı) && a.sifre.Equals(objuser.sifre)).FirstOrDefault();
                    if(obj != null)
                    {
                        Session["UserID"] = obj.ID.ToString();
                        Session["UserName"] = obj.kullanıcıadı.ToString();
                        return RedirectToAction("UserDashBoard");

                    }
                }

            }
            return View(objuser);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserId"] != null)
            {
                
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}