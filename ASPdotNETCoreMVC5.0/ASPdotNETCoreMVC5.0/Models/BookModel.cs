using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ASPdotNETCoreMVC5._0.Enums;
using ASPdotNETCoreMVC5._0.Helpers;
using Microsoft.AspNetCore.Http;

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
        //[MyCustomValidation("abc")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500)]
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose the language of your book")]
        [Display(Name ="Language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int TotalPages { get; set; }

        [Display(Name ="Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }
    }
}