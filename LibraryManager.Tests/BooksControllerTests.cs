using LibraryManager.API.Controllers;
using LibraryManager.API.DTOs;
using LibraryManager.API.Models;
using LibraryManager.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace LibraryManager.Tests
{
    public class BooksControllerTests
    {
        [Fact]
        public async Task GetAll_ReturnsOk_WithListOfBooks()
        { 
            var mockService = new Mock<IBookService>();

            var filter = new BookFilterDto();
            var fakeBooks = new List<Book>
            {
                new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin" }
            };

            mockService.Setup(s => s.GetAllBooksAsync(filter)).ReturnsAsync(fakeBooks);

            var controller = new BooksController(mockService.Object);

            var result = await controller.GetAll(filter);

            var okResult = Assert.IsType<OkObjectResult>(result);

            var returnedBooks = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);

            Assert.Single(returnedBooks);
        }
    }
}