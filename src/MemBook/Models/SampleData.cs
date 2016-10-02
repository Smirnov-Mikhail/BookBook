﻿using System;
using System.Linq;

namespace MemBook.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
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
                        Company = "Анонимус",
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
