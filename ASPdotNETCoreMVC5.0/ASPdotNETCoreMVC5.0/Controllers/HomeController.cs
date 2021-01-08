using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using ASPdotNETCoreMVC5._0.Models;

namespace ASPdotNETCoreMVC5._0.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Birol";
            ViewBag.Data = data;

            ViewBag.Type = new BookModel() { Id = 5, Author = "AYDIN" };
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
