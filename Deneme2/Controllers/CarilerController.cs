using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;
namespace Deneme2.Controllers
{
    public class CarilerController : Controller
    {
        Context _context = new Context();

        // GET: Cariler
        public ActionResult Index()
        {
            var degerler = _context.Carilers.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult CariEkle(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Cari = "Yeni Cari";
                return View();
            }
            else
            {

                ViewBag.Cari = "Cariyi Güncelle";
                return View(_context.Carilers.Find(id));
            }
        }
        [HttpPost]
        public ActionResult CariEkle(Cariler k)
        {
            if(!ModelState.IsValid)
            {
                return View("CariEkle");

            }
            if (k.CariId == 0)
            {
                k.Durum = true;
                _context.Carilers.Add(k);
            }
            else
            {

                var eskiCari = _context.Carilers.Find(k.CariId);
                eskiCari.CariAd = k.CariAd;
                eskiCari.CariSoyad = k.CariSoyad;
                eskiCari.CariUnvan = k.CariUnvan;
                eskiCari.CariSehir = k.CariSehir;
                eskiCari.CariMail   = k.CariMail;


            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cari = _context.Carilers.Find(id);
            cari.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = _context.satisHarakets.Where(x=>x.Cariid == id).ToList();
            return View(degerler);
        }
    }
}