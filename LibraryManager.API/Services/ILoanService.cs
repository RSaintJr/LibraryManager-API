namespace LibraryManager.API.Services
{
    public interface ILoanService
    {
        Task<string> BorrowBookAsync(int bookId, int userId);
        Task<string> ReturnBookAsync(int bookId, int userId);
    }
}