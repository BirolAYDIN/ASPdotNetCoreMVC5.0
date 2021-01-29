using ASPdotNETCoreMVC5._0.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNETCoreMVC5._0.Models;
using Microsoft.AspNetCore.Routing;

namespace ASPdotNETCoreMVC5._0.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();

            return View(data);
        }
        [Route("book-details/{id}")]
        public ViewResult GetBook(int id ,string nameOfBook)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
    }
}
