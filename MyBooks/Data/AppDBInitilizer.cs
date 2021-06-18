using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MyBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data
{
    public class AppDBInitilizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book() { 
                        Title = "1st Book title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "Pritom",
                        CoverUrl = "https://......",
                        DateAdded = DateTime.Now
                    }, 
                    new Book() {
                        Title = "2nd Book title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Economics",
                        Author = "Jugal",
                        CoverUrl = "https://......",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
