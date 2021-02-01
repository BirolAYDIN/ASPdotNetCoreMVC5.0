using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace ASPdotNETCoreMVC5._0.Models
{
    public class BookModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name ="Choose date and time")]
        public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of the book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose the language of your book")]
        public string Language { get; set; }
        [Required(ErrorMessage = "Please choose the languages of your book")]
        public List<string> MultiLanguage { get; set; }
        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int TotalPages { get; set; }
       
    }
}