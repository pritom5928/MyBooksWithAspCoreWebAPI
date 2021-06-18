using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Data.Services
{
    public class BookService
    {
        private AppDBContext _db;
        public BookService(AppDBContext db)
        {
            _db = db;
        }

        public void AddBook(BookVM bookVM)
        {
            var _book = new Book
            {
                Title = bookVM.Title,
                Description = bookVM.Description,
                IsRead = bookVM.IsRead,
                DateRead = bookVM.DateRead != null ? bookVM.DateRead.Value : null,
                Rate = bookVM.Rate,
                Genre = bookVM.Genre,
                Author = bookVM.Author,
                CoverUrl = bookVM.CoverUrl,
                DateAdded = DateTime.Now,
            };

            _db.Books.Add(_book);
            _db.SaveChanges();
        }

        public List<Book> GetAllBooks() => _db.Books.ToList();

        public Book GetBookById(int bookId) => _db.Books.FirstOrDefault(s => s.Id == bookId);


        public Book UpdateBookById(int id, BookVM bookVM)
        {
            var getBook = _db.Books.FirstOrDefault(s => s.Id == id);
            if (getBook != null)
            {
                getBook.Title = bookVM.Title;
                getBook.Description = bookVM.Description;
                getBook.IsRead = bookVM.IsRead;
                getBook.DateRead = bookVM.DateRead != null ? bookVM.DateRead.Value : null;
                getBook.Rate = bookVM.Rate;
                getBook.Genre = bookVM.Genre;
                getBook.Author = bookVM.Author;
                getBook.CoverUrl = bookVM.CoverUrl;

                _db.SaveChanges();
            }

            return getBook;
        }

        public void DeleteBookById(int id)
        {
            var deletedBook = _db.Books.FirstOrDefault(s => s.Id == id);
            if (deletedBook != null)
            {
                _db.Books.Remove(deletedBook);
                _db.SaveChanges();
            }
        }
    }
}
