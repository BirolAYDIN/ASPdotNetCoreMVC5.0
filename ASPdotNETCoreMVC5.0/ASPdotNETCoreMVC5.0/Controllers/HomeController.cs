using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNETCoreMVC5._0.Models;

namespace ASPdotNETCoreMVC5._0.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["book"] = new BookModel() { Id = 10, Author = "Birol AYDIN" };
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
