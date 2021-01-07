using ASPdotNETCoreMVC5._0.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNETCoreMVC5._0.Models;

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

        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
    }
}
