using ASPdotNETCoreMVC5._0.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPdotNETCoreMVC5._0.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace ASPdotNETCoreMVC5._0.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BookController(BookRepository bookRepository , 
            LanguageRepository languageRepository ,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<ViewResult> AddNewBook(bool isSuccess = false ,int bookId = 0)
        {
            var model = new BookModel()
            {
                LanguageId = 1
            };

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages() , "Id" ,"Name");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem() 
            //{ 
            //    Text  = x.Text,
            //    Value = x.Id.ToString()

            //}).ToList();

            //var group1 = new SelectListGroup() { Name = "Group 1" };
            //var group2 = new SelectListGroup() { Name = "Group 2" ,Disabled = true };

            //ViewBag.Language = new List<SelectListItem> { 
            //    new SelectListItem() { Text="English", Value="1" ,Group = group1},
            //    new SelectListItem() { Text="English(U.K)" , Value="2" ,Group = group1},
            //    new SelectListItem() { Text="Turkish" , Value="3", Disabled = true ,Group = group2}
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImageUrl = await UploadImage(folder ,bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();

 

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);
                        
                    }
                    
                }

                int id = await _bookRepository.AddNewBook(bookModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            //var group1 = new SelectListGroup() { Name = "Group 1" };
            //var group2 = new SelectListGroup() { Name = "Group 2", Disabled = true };

            //ViewBag.Language = new List<SelectListItem> {
            //    new SelectListItem() { Text="English", Value="1" ,Group = group1},
            //    new SelectListItem() { Text="English(U.K)" , Value="2" ,Group = group1},
            //    new SelectListItem() { Text="Turkish" , Value="3", Disabled = true ,Group = group2}
            //};

            ModelState.AddModelError("","This is my error message");
            return View();
        }

        private async Task<string> UploadImage(string folderPath ,IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            

            
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

    }
}
