using System;
using GoodBooks.Data.Models;
using GoodBooks.Services;

namespace GoodBooks.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("v1/book")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger,
            IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            if (books != null && books.Count != 0)
                return Ok(books);

            return BadRequest("No books found!");
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _bookService.GetBook(id);
            if (book != null)
                return Ok(book);

            return BadRequest($"Book #{id} not found!");
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Book request)
        {
            var date = DateTime.UtcNow;
            var book = new Book()
            {
                BookAuthor = request.BookAuthor,
                Price = request.Price,
                Title = request.Title,
                CreatedTime = date,
                UpdatedTime = date
            };
            
            _bookService.AddBook(book);

            return Ok($"Book Created: {book.Title}");
        }
    }
}
