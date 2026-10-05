using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinanceiroController : ControllerBase
    {
        private readonly FinanceiroService _financeiroService;

        public FinanceiroController(FinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        [HttpPost("calcular")]
        public IActionResult Calcular([FromBody] CalculoJurosRequest request)
        {
            if (request.ValorOriginal <= 0)
            {
                return BadRequest(new { erro = "O valor original deve ser maior que zero." });
            }

            var resultado = _financeiroService.Calcular(request);
            return Ok(resultado);
        }
    }
}
