using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context _context = new Context();
        // GET: Kargo
        public ActionResult Index()
        {
            var kargolar = _context.kargodetays.ToList();
            return View(kargolar);
        }
        [HttpGet]
        public ActionResult KargoEkle(int id =0)
        {
            if (id == 0)
            {
                Random rnd = new Random();
                string[] karakterler = { "A", "B", "C", "D" };
                int k1, k2, k3;
                k1 = rnd.Next(0, 4);
                k2 = rnd.Next(0, 4);
                k3 = rnd.Next(0, 4);
                int s1, s2, s3;
                s1 = rnd.Next(100, 1000);
                s2 = rnd.Next(10, 99);
                s3 = rnd.Next(10, 99);
                string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
                ViewBag.kod = kod;
                ViewBag.kargo = "Yeni Kargo";
                return View();
            }
            else
            {

                ViewBag.kargo = "Kargoyu Güncelle";
                return View(_context.kargodetays.Find(id));
            }
        }

        [HttpPost]
        public ActionResult KargoEkle(Kargodetay k)
        {
            if (k.KargoDetayid == 0)
            {

                
                _context.kargodetays.Add(k);
            }
            else
            {

                if (!ModelState.IsValid)
                {
                    return View("KargoEkle");

                }

                var eskiKargo = _context.kargodetays.Find(k.KargoDetayid);
                eskiKargo.Aciklama = k.Aciklama;
                eskiKargo.Alici = k.Alici;
                eskiKargo.Personel = k.Personel;
                eskiKargo.TakipKodu = k.TakipKodu;
                eskiKargo.Tarih = k.Tarih;


            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KargoSil(int id)
        {
            var kargo = _context.kargodetays.Find(id);
            _context.kargodetays.Remove(kargo);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}