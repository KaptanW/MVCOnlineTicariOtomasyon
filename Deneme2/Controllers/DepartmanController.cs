using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace Deneme2.Controllers
{
    public class DepartmanController : Controller
    {
        Context _context = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var context = _context.Departmans.Where(x => x.Durum == true).ToList();
            return View(context);
        }

        [HttpGet]
        public ActionResult DepartmanEkle(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.Departman = "Yeni Departman";
                return View();
            }
            else
            {

                ViewBag.Departman = "Departmanı Güncelle";
                return View(_context.Departmans.Find(id));
            }
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman k)
        {
            if (k.Departmanid == 0)
            {

                _context.Departmans.Add(k);
            }
            else
            {

                var eskiDepartman = _context.Departmans.Find(k.Departmanid);
                eskiDepartman.DepartmanAd = k.DepartmanAd;

            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}