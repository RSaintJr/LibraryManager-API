using LibraryManager.API.Data;
using LibraryManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.API.Services
{
    public class LoanService : ILoanService
    {
        private readonly AppDbContext _context;

        public LoanService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> BorrowBookAsync(int bookId, int userId)
        { 
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
                throw new Exception("Livro não encontrado.");

            if (!book.IsAvailable)
                throw new Exception("Este livro já está emprestado e indisponível no momento.");

            var loan = new Loan
            {
                BookId = bookId,
                UserId = userId,
                LoanDate = DateTime.UtcNow
            };

            book.IsAvailable = false;

            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return "Empréstimo realizado com sucesso!";
        }

        public async Task<string> ReturnBookAsync(int bookId, int userId)
        {
            var loan = await _context.Loans
                .FirstOrDefaultAsync(l => l.BookId == bookId && l.UserId == userId && l.ReturnDate == null);

            if (loan == null)
                throw new Exception("Empréstimo ativo não encontrado para este livro e usuário.");

            loan.ReturnDate = DateTime.UtcNow;

            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.IsAvailable = true;
            }

            await _context.SaveChangesAsync();

            return "Livro devolvido com sucesso!";
        }
    }
}