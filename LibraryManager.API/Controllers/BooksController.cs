using LibraryManager.API.DTOs;
using LibraryManager.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] BookFilterDto filter)
        {
            var books = await _bookService.GetAllBooksAsync(filter);
            return Ok(books);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<IActionResult> AddBook([FromBody] BookDto dto)
        {
            var book = await _bookService.AddBookAsync(dto);
            return Ok(book);
        }
    }
}

