using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DersEkle(int? Id)
        {
            if (Id!=null)
            {
                VeritabaniBag bag = new VeritabaniBag();
                var model= bag.Dersler.First(i => i.Id == Id);
                return View(model);
            }
            Ders nesne = new Ders();
            return View(nesne);
        }
        [HttpPost]
        public IActionResult DersEkle(Ders aa)
        {
            if (ModelState.IsValid)
            {
                VeritabaniBag baglanti = new VeritabaniBag();
                if (aa.Id>0)
                {
                    baglanti.Dersler.Update(aa);
                    baglanti.SaveChanges();
                }
                else
                {
                    aa.Tarih = DateTime.Now;
                    baglanti.Dersler.Add(aa);
                    baglanti.SaveChanges();
                }
                return RedirectToAction("derslistele");
            }
            return View(aa);
        }
        public IActionResult dersSil(int Id)
        {
            var baglanti = new VeritabaniBag();
            var model= baglanti.Dersler.First(i => i.Id == Id);
            if (model!=null)
            {
                baglanti.Dersler.Remove(model);
                baglanti.SaveChanges();
            }
            return RedirectToAction("derslistele");
        }
        public IActionResult DersListele()
        {
            VeritabaniBag baglanti = new VeritabaniBag();
            var tumDersler= baglanti.Dersler.ToList();
            return View(tumDersler);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
