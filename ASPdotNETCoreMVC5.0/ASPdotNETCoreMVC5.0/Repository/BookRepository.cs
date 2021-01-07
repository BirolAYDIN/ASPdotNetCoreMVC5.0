using ASPdotNETCoreMVC5._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ASPdotNETCoreMVC5._0.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
                new BookModel(){ Id = 3, Title="Java Script", Author="Birol AYDIN",Description="Some quick example text to build on the card title and make up the bulk of the card's content."}
            };
        }
    }
}
