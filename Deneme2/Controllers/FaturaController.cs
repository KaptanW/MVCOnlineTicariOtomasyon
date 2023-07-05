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
                ViewBag.fatura = "Yeni Fatura";
                return View();
            }
            else
            {

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
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}