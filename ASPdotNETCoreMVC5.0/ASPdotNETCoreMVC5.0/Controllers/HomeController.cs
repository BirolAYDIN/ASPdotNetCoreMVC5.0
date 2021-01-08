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
        [ViewData]
        public string  CustomProperty { get; set; }
        public ViewResult Index()
        {
            CustomProperty = "Custom Value";
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
