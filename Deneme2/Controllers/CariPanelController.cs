using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deneme2.Controllers
{
    public class CariPanelController : Controller
    {
        Context _context = new Context();
        // GET: CariPanel

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"]; 
            var degerler = _context.Carilers.FirstOrDefault(x=>x.CariMail == mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler k)
        {


            var mail = (string)Session["CariMail"];
            var eskiCari = _context.Carilers.FirstOrDefault(x => x.CariMail == mail);
                eskiCari.CariAd = k.CariAd;
                eskiCari.CariSoyad = k.CariSoyad;
                eskiCari.CariUnvan = k.CariUnvan;
                eskiCari.CariSehir = k.CariSehir;
                eskiCari.CariMail = k.CariMail;
            eskiCari.CariSifre = k.CariSifre;
            _context.SaveChanges();
            return RedirectToAction("Index");


        }
            public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = _context.Carilers.Where(x=>x.CariMail == mail.ToString()).Select(y=>y.CariId).FirstOrDefault();
            var degerler = _context.satisHarakets.Where(x=>x.Cariid ==id).ToList();
            return View(degerler);
        }
    }
}