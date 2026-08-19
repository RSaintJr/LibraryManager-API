using System.ComponentModel.DataAnnotations;

namespace LibraryManager.API.DTOs
{
    public class BorrowBookDto
    {
        [Required(ErrorMessage = "O ID do livro é obrigatório.")]
        public int BookId { get; set; }
    }
}