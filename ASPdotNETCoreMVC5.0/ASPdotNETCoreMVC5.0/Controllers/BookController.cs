using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPdotNETCoreMVC5._0.Controllers
{
    public class BookController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public string GetAllBooks()
        {
            return "All Books";
        }

        public string GetBook(int id)
        {
            return $"book with id: {id}";
        }

        public string SearchBook(string bookName , string authorName)
        {
            return $"Book with name = {bookName} & Author = {authorName}";
        }
    }
}
