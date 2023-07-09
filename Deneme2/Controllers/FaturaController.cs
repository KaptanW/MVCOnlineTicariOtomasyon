using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace Deneme2.Controllers
{
    
    public class FaturaController : Controller
    {
        bool güncelleme = false;
        Context _context = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var degerler = _context.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle(int id = 0)
        {

            if (id == 0)
            {
                güncelleme = false;
                ViewBag.faturadetay = güncelleme;
                ViewBag.fatura = "Yeni Fatura";
                return View();
            }
            else
            {
                güncelleme = true;
                ViewBag.faturadetay = güncelleme;
                ViewBag.fatura = "Faturayı Değiştir";
                return View(_context.Faturalars.Find(id));
            }
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            if (fatura.FaturaId == 0)
            {


                _context.Faturalars.Add(fatura);
            }
            else
            {

                var eskifatura = _context.Faturalars.Find(fatura.FaturaId);
                eskifatura.FaturaSeriNo = fatura.FaturaSeriNo;
                eskifatura.FaturaSıraNo = fatura.FaturaSıraNo;
                eskifatura.Saat = fatura.Saat;
                eskifatura.Tarih = fatura.Tarih;
                eskifatura.TeslimAlan = fatura.TeslimAlan;
                eskifatura.TeslimEden  = fatura.TeslimEden;

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var deger = _context.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return PartialView("FaturaKalem",deger);
        }

        public ActionResult FaturaDetaySil(int id)
        {
            var kate = _context.FaturaKalems.Find(id);
            _context.FaturaKalems.Remove(kate);
            _context.SaveChanges();
            
            return RedirectToAction("FaturaEkle/"+ kate.Faturaid);
        }


        int fatura;
        [HttpGet]
        public ActionResult FaturaKalemEkle(int id)
        {
            fatura = id;
            return View();
        }

        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem faturaKalem, int id)
        {
            faturaKalem.Faturaid = id;
            _context.FaturaKalems.Add(faturaKalem);
            _context.SaveChanges();
            return RedirectToAction("FaturaEkle/"+id);
        }
    }
}