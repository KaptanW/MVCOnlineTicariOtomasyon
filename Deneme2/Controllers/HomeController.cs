using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;


namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        Context _context = new Context();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.d1 = _context.Carilers.Count().ToString();
            ViewBag.d2 = _context.Uruns.Count().ToString();
            ViewBag.d3 = _context.Kategoris.Count().ToString();
            ViewBag.d4 = (from x in _context.Carilers select x.CariSehir).Distinct().Count().ToString();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public PartialViewResult toDo()
        {
            var deger = _context.toDos.ToList();
            return PartialView(deger);
        }

        [HttpGet]
        public PartialViewResult AddToDo() {
            return PartialView();
        }
    }
}