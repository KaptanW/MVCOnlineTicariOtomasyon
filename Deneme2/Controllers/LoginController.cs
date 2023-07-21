using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace Deneme2.Controllers
{
    public class LoginController : Controller
    {
        Context _context = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Kayıt()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Kayıt(Cariler cari)
        {
            _context.Carilers.Add(cari);
            _context.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Login(Cariler cari)
        {
            var deger = _context.Carilers.FirstOrDefault(x=>x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.CariMail, false);
                Session["CariMail"]=deger.CariMail.ToString();
                return RedirectToAction("Index","CariPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var deger = _context.Admins.FirstOrDefault(x=>x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAd, false);
                Session["AdminMail"]=admin.KullaniciAd.ToString();
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }
    }
}