using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {

        Context _context = new Context();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = _context.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle(int id=0)
        {
            if(id == 0)
            {
                ViewBag.Kategori = "Yeni Kategori";
                return View();
            }
            else
            {

                ViewBag.Kategori = "Kategoriyi Değiştir";
                return View(_context.Kategoris.Find(id));
            }
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            if (k.KategoriId == 0)
            {

                _context.Kategoris.Add(k);
            }
            else
            {
                
                var eskikategori = _context.Kategoris.Find(k.KategoriId);
                eskikategori.KategoriAd = k.KategoriAd;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kate = _context.Kategoris.Find(id);
            _context.Kategoris.Remove(kate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}