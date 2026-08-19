using System.ComponentModel.DataAnnotations;

namespace LibraryManager.API.DTOs
{
    public class ReturnBookDto
    {
        [Required(ErrorMessage = "O ID do livro é obrigatório.")]
        public int BookId { get; set; }
    }
}