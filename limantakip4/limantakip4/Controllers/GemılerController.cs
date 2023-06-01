using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using limantakip4.Models;

namespace limantakip4.Controllers
{
    public class GemılerController : Controller
    {
        takipsistemiEntities db = new takipsistemiEntities();
        // GET: Gemıler
        public ActionResult Index()
        {
            var list = db.Gemıı.ToList();
            return View(list);

        }
        [HttpGet]
        public ActionResult GemitEkle()
        {
            List<SelectListItem> degerler = (from i in db.Gemıı.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.GEMIULLIMAN,
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult GemitEkle(Gemıı s1)
        {
            db.Gemıı.Add(s1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var Gemiler = db.Gemıı.Find(id);
            db.Gemıı.Remove(Gemiler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GemiGetir(int? id)
        {
            var Gemiler = db.Gemıı.Find(id);
            return View("GemiGetir", Gemiler);
        }
        public ActionResult Guncelle(Gemıı p1)
        {
            var Gemiler = db.Gemıı.Find(p1.ID);
            Gemiler.ID = p1.ID;
            Gemiler.GEMIYUK = p1.GEMIYUK;
            Gemiler.GEMIYUKTONU = p1.GEMIYUKTONU;
            Gemiler.GEMIMURETTEBAT = p1.GEMIMURETTEBAT;
            Gemiler.GEMIBAYRAK = p1.GEMIBAYRAK;
            Gemiler.GEMIBULLIMAN = p1.GEMIBULLIMAN;
            Gemiler.GEMIULLIMAN = p1.GEMIULLIMAN;
            Gemiler.GEMISIRKET = p1.GEMISIRKET;
            Gemiler.GEMICIKTARIH = p1.GEMICIKTARIH;
            Gemiler.GEMIVARTARIH = p1.GEMIVARTARIH;

            return RedirectToAction("Index");
        }
    }
}