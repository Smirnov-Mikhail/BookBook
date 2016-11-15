using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MemBook.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        [DataType(DataType.Currency)]
        public int Price { get; set; }
        public string Annotation { get; set; }
        public string ImageUrl { get; set; }
    }
}
