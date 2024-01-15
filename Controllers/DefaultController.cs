using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalmedya = db.TblSosyalMedya.Where(x => x.Durum == true).ToList();
                return PartialView(sosyalmedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyim = db.TblDeneyimlerim.ToList();
            return PartialView(deneyim);
        }
        public PartialViewResult Egitim()
        {
            var egitim = db.TblEgitimlerim.ToList();
            return PartialView(egitim);
        }
        public PartialViewResult Yetenek()
        {
            var yetenek = db.TblYeteneklerim.ToList();
            return PartialView(yetenek);
        }
        public PartialViewResult Hobi()
        {
            var hobi = db.TblHobilerim.ToList();
            return PartialView(hobi);

        }
        public PartialViewResult Sertifika()
        {
            var sertifika = db.TblSertifikalarim.ToList();
            return PartialView(sertifika);
        }

        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}