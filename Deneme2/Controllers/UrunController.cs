using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace Deneme2.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context _context = new Context();
        public ActionResult Index()
        {
            var urunler = _context.Uruns.Where(x=>x.Durum==true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult UrunEkle(int id=0)
        {
            List<SelectListItem> list = (from x in _context.Kategoris.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.KategoriAd,
                                             Value = x.KategoriId.ToString()
                                         }).ToList();

            ViewBag.KategoriListesi = list;
            if (id == 0)
            {
                ViewBag.Urun = "Yeni Ürün";
                return View();
            }
            else
            {

                ViewBag.Urun = "Ürünü Değiştir";
                return View(_context.Uruns.Find(id));
            }
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            if (urun.UrunId == 0) {


                _context.Uruns.Add(urun);
            }
            else
            {

                var eurun = _context.Uruns.Find(urun.UrunId);
                eurun.UrunAd = urun.UrunAd;
                eurun.Marka = urun.Marka;
                eurun.AlisFiyat = urun.AlisFiyat;
                eurun.SatisFiyat = urun.SatisFiyat;
                eurun.Kategoriid = urun.Kategoriid;
                eurun.Durum = urun.Durum;
                eurun.Stok = urun.Stok;
                eurun.UrunGorsel = urun.UrunGorsel;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id )
        {
            var deger = _context.Uruns.Find(id);
            deger.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = _context.Uruns.ToList();
            return View(degerler);
        }
    }
}