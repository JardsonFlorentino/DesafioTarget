using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _estoqueService;

        public EstoqueController(EstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public IActionResult GetEstoque() => Ok(_estoqueService.ObterEstoque());

        [HttpGet("movimentacoes")]
        public IActionResult GetMovimentacoes() => Ok(_estoqueService.ObterMovimentacoes());

        [HttpPost("movimentar")]
        public IActionResult RegistrarMovimentacao([FromBody] Movimentacao mov)
        {
            try
            {
                int estoqueFinal = _estoqueService.RegistrarMovimentacao(mov);
                return Ok(new { mensagem = "Movimentação registrada com sucesso", estoqueFinal = estoqueFinal });
            }
            catch (Exception ex) { return BadRequest(new { erro = ex.Message }); }
        }

        // ====== NOVAS ROTAS DO CRUD DE PRODUTOS ====== //

        [HttpPost("produto")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try { return Ok(_estoqueService.AdicionarProduto(produto)); }
            catch (Exception ex) { return BadRequest(new { erro = ex.Message }); }
        }

        [HttpPut("produto/{codigo}")]
        public IActionResult AtualizarProduto(int codigo, [FromBody] Produto produto)
        {
            try { return Ok(_estoqueService.AtualizarProduto(codigo, produto)); }
            catch (Exception ex) { return BadRequest(new { erro = ex.Message }); }
        }

        [HttpDelete("produto/{codigo}")]
        public IActionResult DeletarProduto(int codigo)
        {
            try
            {
                _estoqueService.DeletarProduto(codigo);
                return Ok(new { mensagem = "Produto excluído do catálogo" });
            }
            catch (Exception ex) { return BadRequest(new { erro = ex.Message }); }
        }
    }
}
