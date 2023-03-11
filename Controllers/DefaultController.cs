using Microsoft.AspNetCore.Mvc;
using WebProjectOOP.Examples;

namespace WebProjectOOP.Controllers
{
    public class DefaultController : Controller
    {
        public void Messages()
        {
            ViewBag.m1 = "Akın CENGİZ";
            ViewBag.m2 = "İlk ASP.Net Sayfam...";
            ViewBag.m3 = "Güzzel bir başlangıç yaptık...";
        }
        public IActionResult Index()
        {
            Messages();
            return View();
        }

        public IActionResult Products()
        {
            Messages();
            return View();
        }

        public IActionResult DenemeCity()
        {
            Cities cities = new Cities();
            cities.CityName = "İstanbul";
            cities.Population = 17000000;
            cities.Id = 34;
            cities.Country = "Türkiye";
            ViewBag.v1 = cities.Id;
            ViewBag.v2 = cities.CityName;
            ViewBag.v3 = cities.Population;
            ViewBag.v4 = cities.Country;
            return View();
        }
    }
}
