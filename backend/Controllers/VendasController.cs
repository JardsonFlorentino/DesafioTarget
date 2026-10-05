using Microsoft.AspNetCore.Mvc;
using TargetApi.Models;
using TargetApi.Services;

namespace TargetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly VendaService _vendaService;

        public VendasController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public IActionResult GetTodasAsVendas()
        {
            var vendas = _vendaService.LerVendas();
            return Ok(vendas);
        }

        [HttpGet("comissoes")]
        public IActionResult GetComissoes()
        {
            var comissoes = _vendaService.CalcularComissoes();
            return Ok(comissoes);
        }

        // Rota para ADICIONAR (POST)
        [HttpPost]
        public IActionResult Adicionar([FromBody] Venda novaVenda)
        {
            _vendaService.AdicionarVenda(novaVenda);
            return Ok(new { mensagem = "Venda adicionada com sucesso!" });
        }

        // Rota para EDITAR (PUT)
        [HttpPut("{id}")]
        public IActionResult Editar(string id, [FromBody] Venda vendaEditada)
        {
            bool sucesso = _vendaService.EditarVenda(id, vendaEditada);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Venda não encontrada!" });
            }

            return Ok(new { mensagem = "Venda atualizada com sucesso!" });
        }

        // Rota para EXCLUIR (DELETE)
        [HttpDelete("{id}")]
        public IActionResult Excluir(string id)
        {
            bool sucesso = _vendaService.ExcluirVenda(id);

            if (!sucesso)
            {
                return NotFound(new { mensagem = "Venda não encontrada!" });
            }

            return Ok(new { mensagem = "Venda excluída com sucesso!" });
        }
    }
}
