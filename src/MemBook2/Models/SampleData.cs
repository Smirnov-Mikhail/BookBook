using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemBook.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //Так заработало!
            var context = serviceProvider.GetService(typeof(BookContext)) as BookContext;

            if (context != null && !context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Name = "Война и мир",
                        Company = "Толстой и жена",
                        Price = 600
                    },
                    new Book
                    {
                        Name = "Мемология",
                        Company = "Господь",
                        Price = 100500
                    },
                    new Book
                    {
                        Name = "Отцы и дети",
                        Company = "Ланит-ТурКом",
                        Price = 500
                    }
                );
                
                context.SaveChanges();
            }
        }
    }
}
