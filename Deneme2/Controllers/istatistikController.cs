using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace Deneme2.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
        Context _context = new Context();
        public ActionResult Index()
        {
            ViewBag.d1 = _context.Carilers.Count();
            ViewBag.d2 = _context.Uruns.Count();
            ViewBag.d3 = _context.Personels.Count();
            ViewBag.d4 = _context.Kategoris.Count();
            ViewBag.d5 = _context.Uruns.Sum(x=>x.Stok);
            ViewBag.d6 = (from x in _context.Uruns select x.Marka).Distinct().Count();
            ViewBag.d7 = _context.Uruns.Count(x=> x.Stok <=20);
            ViewBag.d8 = (from x in _context.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = (from x in _context.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d12 = _context.Uruns.GroupBy(x=>x.Marka).Count();
            ViewBag.d10 = _context.Uruns.Where(x => x.Kategoriid == 1).Count();
            ViewBag.d11 = _context.Uruns.Where(x => x.Kategoriid == 3).Count();
            ViewBag.d14 = _context.satisHarakets.Sum(x=>x.ToplamTutar);
            ViewBag.d13 = //
            ViewBag.d15 = _context.satisHarakets.Count(x=>x.Tarih == DateTime.Today);
            return View();
        }

        public ActionResult SimpleTables()
        {
            var sorgu = from x in _context.Carilers
                        group x by x.CariSehir into g
                        select new sinifgrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in _context.Personels
                        group x by x.Departman.DepartmanAd into g
                        select new sinifgrup2
                        {
                            departman = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu2.ToList());
        }
        
        public PartialViewResult Partial2()
        {
            var sorgu = _context.Carilers.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = _context.Uruns.ToList();
            return PartialView(sorgu);
        }
        public PartialViewResult Partial4()
        {
            var sorgu = from x in _context.Uruns
                        group x by x.Marka into g
                        select new sinifgrup3
                        {
                             marka = g.Key,
                            sayi = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }
    }
}