using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using limantakip4.Models;

namespace limantakip4.Controllers
{
    public class LimanlarController : Controller
    {

        // GET: Limanlar
         takipsistemiEntities db = new takipsistemiEntities();
        public ActionResult Index()
        {
            var list = db.Lımann.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult LimanEkle()
        {
            List<SelectListItem> degerler = (from i in db.Lımann.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.LIMANAD,
                                             
                                                 Value = i.ID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult LimanEkle(Lımann s1)
        {
            db.Lımann.Add(s1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var Lımanlar = db.Lımann.Find(id);
            db.Lımann.Remove(Lımanlar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LimanGetir(int? id)
        {
            var Lımanlar = db.Lımann.Find(id);
            return View("LimanGetir", Lımanlar);
        }
        public ActionResult Guncelle(Lımann p1)
        {
            var Lımanlar = db.Lımann.Find(p1.ID);
            Lımanlar.ID = p1.ID;
            Lımanlar.LIMANAD = p1.LIMANAD;
            Lımanlar.LIMANSEHIR = p1.LIMANSEHIR;
            Lımanlar.LIMANULKE = p1.LIMANULKE;
            Lımanlar.LIMANAD = p1.LIMANAD;
            

            return RedirectToAction("Index");
        }
    }
}