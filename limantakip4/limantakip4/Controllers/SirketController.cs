using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using limantakip4.Models;

namespace limantakip4.Controllers
{
    public class SirketController : Controller
    {
        // GET: Sirket
        

        takipsistemiEntities db = new takipsistemiEntities();
        
        
        public ActionResult Index()
        {
            var list=db.Sırkett.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult SırketEkle()
        {
            List<SelectListItem> degerler = (from i in db.Sırkett.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.SIRKETAD,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult SırketEkle(Sırkett s1)
        {
            db.Sırkett.Add(s1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var Sirket = db.Sırkett.Find(id);
            db.Sırkett.Remove(Sirket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SırketGetir(int? id)
        {
            var Sirket = db.Sırkett.Find(id);
            return View("SırketGetir", Sirket);
        }
        public ActionResult Guncelle(Sırkett p1)
        {
            var Sirket = db.Sırkett.Find(p1.ID);
            Sirket.ID = p1.ID;
            Sirket.SIRKETAD = p1.SIRKETAD;
            return RedirectToAction("Index");
        }
    }
}