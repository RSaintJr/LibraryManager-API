using LibraryManager.API.Data;
using LibraryManager.API.DTOs;
using LibraryManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.API.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync(BookFilterDto filter)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
            {
                query = query.Where(b =>
                    b.Title.ToLower().Contains(filter.SearchTerm.ToLower()) ||
                    b.Author.ToLower().Contains(filter.SearchTerm.ToLower()));
            }

            var skip = (filter.PageNumber - 1) * filter.PageSize;

            return await query
                .Skip(skip)
                .Take(filter.PageSize)
                .ToListAsync();
        }

        public async Task<Book> AddBookAsync(BookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                ISBN = dto.ISBN,
                PublicationYear = dto.PublicationYear,
                IsAvailable = true
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}