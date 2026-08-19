using LibraryManager.API.DTOs;
using LibraryManager.API.Models;

namespace LibraryManager.API.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(BookFilterDto filter);
        Task<Book> AddBookAsync(BookDto dto);
    }
}