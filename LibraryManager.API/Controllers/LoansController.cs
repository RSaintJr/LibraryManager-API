using System.Security.Claims;
using LibraryManager.API.DTOs;
using LibraryManager.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LoansController : ControllerBase
    {
        private readonly ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow([FromBody] BorrowBookDto dto)
        {
            try
            { 
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userIdString))
                    return Unauthorized(new { error = "Usuário inválido no token." });

                int userId = int.Parse(userIdString);

                var result = await _loanService.BorrowBookAsync(dto.BookId, userId);

                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("return")]
        public async Task<IActionResult> Return([FromBody] ReturnBookDto dto)
        {
            try
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userIdString))
                    return Unauthorized(new { error = "Usuário inválido no token." });

                int userId = int.Parse(userIdString);

                var result = await _loanService.ReturnBookAsync(dto.BookId, userId);

                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}