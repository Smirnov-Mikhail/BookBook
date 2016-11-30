using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MemBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        public string Annotation { get; set; }
        public string ImageUrl { get; set; }
    }
}
