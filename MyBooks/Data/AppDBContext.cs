using Microsoft.EntityFrameworkCore;
using MyBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
