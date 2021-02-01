using ASPdotNETCoreMVC5._0.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNETCoreMVC5._0.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPdotNETCoreMVC5._0.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public  async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }
        [Route("book-details/{id}")]
        public async Task<ViewResult> GetBook(int id ,string nameOfBook)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName , string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess = false ,int bookId = 0)
        {
            var model = new BookModel()
            {
                Language = "1"
            };

            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem() 
            //{ 
            //    Text  = x.Text,
            //    Value = x.Id.ToString()

            //}).ToList();

            ViewBag.Language = new List<SelectListItem> { 
                new SelectListItem() { Text="English", Value="1"},
                new SelectListItem() { Text="English(U.K)" , Value="2"},
                new SelectListItem() { Text="Turkish" , Value="3", Disabled = true}
            };

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(GetLanguage(),"Id" ,"Text");

            ModelState.AddModelError("","This is my error message");
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() { Id=1,Text="English" },
                new LanguageModel() { Id=2,Text="English(U.K)" }
            };
        }
    }
}
