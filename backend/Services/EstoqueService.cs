using System.Text.Json;
using backend.Models;

namespace backend.Services
{
    public class EstoqueService
    {
        private readonly string _estoqueFilePath = "Data/estoque.json";
        private readonly string _movimentacoesFilePath = "Data/movimentacoes.json";

        public EstoqueService()
        {
            if (!Directory.Exists("Data")) Directory.CreateDirectory("Data");

            if (!File.Exists(_estoqueFilePath))
            {
                var produtosIniciais = new List<Produto>
                {
                    new Produto { CodigoProduto = 101, DescricaoProduto = "Caneta Azul", EstoqueAtual = 150 },
                    new Produto { CodigoProduto = 102, DescricaoProduto = "Caderno Universitário", EstoqueAtual = 75 },
                    new Produto { CodigoProduto = 103, DescricaoProduto = "Borracha Branca", EstoqueAtual = 200 },
                    new Produto { CodigoProduto = 104, DescricaoProduto = "Lápis Preto HB", EstoqueAtual = 320 },
                    new Produto { CodigoProduto = 105, DescricaoProduto = "Marcador de Texto Amarelo", EstoqueAtual = 90 }
                };
                File.WriteAllText(_estoqueFilePath, JsonSerializer.Serialize(produtosIniciais));
            }

            if (!File.Exists(_movimentacoesFilePath))
                File.WriteAllText(_movimentacoesFilePath, "[]");
        }

        public List<Produto> ObterEstoque()
        {
            var json = File.ReadAllText(_estoqueFilePath);
            return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
        }

        public List<Movimentacao> ObterMovimentacoes()
        {
            var json = File.ReadAllText(_movimentacoesFilePath);
            return JsonSerializer.Deserialize<List<Movimentacao>>(json) ?? new List<Movimentacao>();
        }

        // ====== CRUD DO CATÁLOGO DE PRODUTOS ====== //

        public Produto AdicionarProduto(Produto novo)
        {
            var estoque = ObterEstoque();
            if (estoque.Any(p => p.CodigoProduto == novo.CodigoProduto))
                throw new Exception("Já existe um produto com este código!");

            estoque.Add(novo);
            File.WriteAllText(_estoqueFilePath, JsonSerializer.Serialize(estoque));
            return novo;
        }

        public Produto AtualizarProduto(int codigo, Produto atualizado)
        {
            var estoque = ObterEstoque();
            var produto = estoque.FirstOrDefault(p => p.CodigoProduto == codigo);

            if (produto == null) throw new Exception("Produto não encontrado.");

            // REGRA DE OURO: Atualiza o nome, mas NUNCA o saldo por aqui!
            produto.DescricaoProduto = atualizado.DescricaoProduto;

            File.WriteAllText(_estoqueFilePath, JsonSerializer.Serialize(estoque));
            return produto;
        }

        public void DeletarProduto(int codigo)
        {
            var estoque = ObterEstoque();
            var produto = estoque.FirstOrDefault(p => p.CodigoProduto == codigo);
            if (produto == null) throw new Exception("Produto não encontrado.");

            estoque.Remove(produto);
            File.WriteAllText(_estoqueFilePath, JsonSerializer.Serialize(estoque));
        }

        // ====== A REGRA DO DESAFIO (MOVIMENTAÇÕES) ====== //

        public int RegistrarMovimentacao(Movimentacao mov)
        {
            var estoque = ObterEstoque();
            var produto = estoque.FirstOrDefault(p => p.CodigoProduto == mov.CodigoProduto);

            if (produto == null) throw new Exception("Produto não encontrado.");

            if (mov.TipoMovimentacao.ToUpper() == "ENTRADA")
            {
                produto.EstoqueAtual += mov.Quantidade;
            }
            else if (mov.TipoMovimentacao.ToUpper() == "SAIDA")
            {
                if (produto.EstoqueAtual < mov.Quantidade)
                    throw new Exception("Estoque insuficiente para esta saída!");

                produto.EstoqueAtual -= mov.Quantidade;
            }
            else
            {
                throw new Exception("Tipo inválido. Use ENTRADA ou SAIDA.");
            }

            File.WriteAllText(_estoqueFilePath, JsonSerializer.Serialize(estoque));

            var movimentacoes = ObterMovimentacoes();
            movimentacoes.Add(mov);
            File.WriteAllText(_movimentacoesFilePath, JsonSerializer.Serialize(movimentacoes));

            return produto.EstoqueAtual;
        }
    }
}
