using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace Deneme2.Controllers
{
    public class PersonelController : Controller
    {
        Context _context = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = _context.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle(int id = 0)
        {
            List<SelectListItem> list = (from x in _context.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.Departmanid.ToString()
                                         }).ToList();

            ViewBag.Departmanlistesi = list;
            if (id == 0)
            {
                ViewBag.personel = "Yeni Personel";
                return View();
            }
            else
            {

                ViewBag.personel = "Personeli Değiştir";
                return View(_context.Personels.Find(id));
            }
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (personel.PersonelId == 0)
            {


                _context.Personels.Add(personel);
            }
            else
            {

                var eskipersonel = _context.Personels.Find(personel.PersonelId);
                eskipersonel.PersonelAd = personel.PersonelAd;
                eskipersonel.PersonelSoyad = personel.PersonelSoyad;
                eskipersonel.PersonelGorsel = personel.PersonelGorsel;
                eskipersonel.Departmanid = personel.Departmanid;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}