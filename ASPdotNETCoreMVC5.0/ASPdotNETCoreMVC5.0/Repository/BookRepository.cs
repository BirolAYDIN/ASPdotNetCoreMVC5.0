using ASPdotNETCoreMVC5._0.Data;
using ASPdotNETCoreMVC5._0.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ASPdotNETCoreMVC5._0.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                TotalPages =bookModel.TotalPages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn =DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    }); ;

                }
            }
            return books; 
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages

                };
                return bookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title , string authorName)
        {
            // return DataSource().Where(x => x.Title == title & x.Author == authorName).ToList();
            // return DataSource().Where(x => x.Title.ToLower().Contains(title.ToLower()) & x.Author.ToLower().Contains(authorName.ToLower())).ToList();
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id = 1, Title="ASP.Core MVC", Author="Birol AYDIN" ,Description="Some quick example text to build on the card title and make up the bulk of the card's content."},
                new BookModel(){ Id = 2, Title="Dot Net Core" , Author="Birol Aydın",Description="Some quick example text to build on the card title and make up the bulk of the card's content."},
                new BookModel(){ Id = 3, Title="Java Script", Author="Birol AYDIN",Description="Some quick example text to build on the card title and make up the bulk of the card's content."},
                new BookModel(){ Id = 4, Title="Php", Author="Birol AYDIN" ,Description="Some quick example text to build on the card title and make up the bulk of the card's content."},
                new BookModel(){ Id = 5, Title="Java" , Author="Birol Aydın",Description="Some quick example text to build on the card title and make up the bulk of the card's content."},
                new BookModel(){ Id = 6, Title="HTML5", Author="Birol AYDIN",Description="Some quick example text to build on the card title and make up the bulk of the card's content."}
            };
        }
    }
}
