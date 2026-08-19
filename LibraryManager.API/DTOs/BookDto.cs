using System.ComponentModel.DataAnnotations;

namespace LibraryManager.API.DTOs
{
    public class BookDto
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "O autor é obrigatório.")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        public string ISBN { get; set; } = string.Empty;

        public int PublicationYear { get; set; }
    }
}