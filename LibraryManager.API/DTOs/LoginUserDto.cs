using System.ComponentModel.DataAnnotations;

namespace LibraryManager.API.DTOs
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; } = string.Empty;
    }
}