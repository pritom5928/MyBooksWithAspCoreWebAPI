using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Services;
using MyBooks.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("Save-Book")]
        public ActionResult SaveBook([FromBody] BookVM bookVM)
        {
            _bookService.AddBook(bookVM);

            return Ok();
        }


        [HttpGet("Get-all-book")]
        public ActionResult GetAllBooks()
        {
           var allBooks =  _bookService.GetAllBooks();

            return Ok(allBooks);
        }


        [HttpGet("Get-book-by-Id/{bookId}")]
        public ActionResult GetBookById(int bookId)
        {
            var bookObj = _bookService.GetBookById(bookId);

            return Ok(bookObj);
        }

        [HttpPut("Update-book-by-Id/{id}")]
        public ActionResult UpdateBookById(int id, [FromBody] BookVM bookVM)
        {
            var updatedBook = _bookService.UpdateBookById(id, bookVM);

            return Ok(updatedBook);
        }

        [HttpDelete("Delete-book-by-Id/{id}")]
        public ActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);

            return Ok();
        }

    }
}
