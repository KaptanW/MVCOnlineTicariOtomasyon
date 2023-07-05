using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;
namespace Deneme2.Controllers
{
    public class SatisController : Controller
    {

        Context _context = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = _context.satisHarakets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisEkle(int id=0)
        {
            List<SelectListItem> listurun = (from x in _context.Uruns.Where(x=>x.Durum == true).ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunId.ToString()
                                         }).ToList();

            List<SelectListItem> listcari = (from x in _context.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd,
                                             Value = x.CariId.ToString()
                                         }).ToList();
            List<SelectListItem> listpersonel = (from x in _context.Personels.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.PersonelAd,
                                             Value = x.PersonelId.ToString()
                                         }).ToList();
            ViewBag.Urunlistesi=listurun;
            ViewBag.Carilistesi= listcari;
            ViewBag.Personellistesi= listpersonel;


            if (id == 0)
            {
                ViewBag.Satis = "Yeni Satış";

                return View();
            }
            else
            {

                ViewBag.Satis = "Satışı Değiştir";
                return View(_context.satisHarakets.Find(id));
            }


        }
        [HttpPost]
        public ActionResult SatisEkle(SatisHaraket satis)
        {
            if (satis.SatisId == 0)
            {

                var urun = _context.Uruns.Find(satis.Urunid);
                satis.Fiyat = urun.SatisFiyat;
                satis.ToplamTutar = (satis.Adet) * satis.Fiyat;
                satis.Tarih = DateTime.Now;
                _context.satisHarakets.Add(satis);
            }
            else
            {

                var eskisatis = _context.satisHarakets.Find(satis.SatisId);
                var urun = _context.Uruns.Find(satis.Urunid);
                eskisatis.Urunid = satis.Urunid;
                eskisatis.Fiyat = urun.SatisFiyat;
                eskisatis.Adet = satis.Adet;
                eskisatis.Cariid = satis.Cariid;
                eskisatis.Personelid = satis.Personelid;
                eskisatis.ToplamTutar = (satis.Adet) * eskisatis.Fiyat;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = _context.satisHarakets.Where(x=>x.SatisId == id).ToList();
            return View(degerler);
        }
    }
}