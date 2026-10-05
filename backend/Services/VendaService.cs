using System.Text.Json;
using TargetApi.Models;

namespace TargetApi.Services
{
    public class VendaService
    {
        private readonly string _caminhoArquivo = "Data/vendas.json";

        private class EnvelopeJson
        {
            [System.Text.Json.Serialization.JsonPropertyName("vendas")]
            public List<Venda>? Vendas { get; set; }
        }

        public List<Venda> LerVendas()
        {
            if (!File.Exists(_caminhoArquivo))
            {
                return new List<Venda>();
            }

            string textoJson = File.ReadAllText(_caminhoArquivo);

            var envelope = JsonSerializer.Deserialize<EnvelopeJson>(textoJson);

            return envelope?.Vendas ?? new List<Venda>();
        }

        public List<ComissaoResultado> CalcularComissoes()
        {
            var todasAsVendas = LerVendas();
            var resultados = new List<ComissaoResultado>();
            var vendasAgrupadas = todasAsVendas.GroupBy(v => v.Vendedor);

            foreach (var grupo in vendasAgrupadas)
            {
                string nome = grupo.Key ?? "Desconhecido";
                decimal somaVendas = 0;
                decimal somaComissao = 0;

                foreach (var venda in grupo)
                {
                    somaVendas += venda.Valor;

                    if (venda.Valor < 100)
                    {
                        somaComissao += 0;
                    }
                    else if (venda.Valor < 500)
                    {
                        somaComissao += venda.Valor * 0.01m;
                    }
                    else
                    {
                        somaComissao += venda.Valor * 0.05m;
                    }
                }

                resultados.Add(new ComissaoResultado
                {
                    NomeVendedor = nome,
                    TotalVendas = somaVendas,
                    TotalComissao = somaComissao
                });
            }

            return resultados;
        }

        // Função para reescrever o arquivo JSON
        private void SalvarVendas(List<Venda> vendasAtualizadas)
        {
            var envelope = new EnvelopeJson { Vendas = vendasAtualizadas };
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string novoTexto = JsonSerializer.Serialize(envelope, opcoes);

            File.WriteAllText(_caminhoArquivo, novoTexto);
        }
        public void AdicionarVenda(Venda novaVenda)
        {
            var vendas = LerVendas();
            novaVenda.Id = Guid.NewGuid().ToString(); // Gera o ID automático e seguro

            vendas.Add(novaVenda);
            SalvarVendas(vendas);
        }
        public bool EditarVenda(string id, Venda vendaEditada)
        {
            var vendas = LerVendas();
            var vendaExistente = vendas.FirstOrDefault(v => v.Id == id);

            if (vendaExistente == null) return false;

            vendaExistente.Vendedor = vendaEditada.Vendedor;
            vendaExistente.Valor = vendaEditada.Valor;

            SalvarVendas(vendas);
            return true;
        }
        public bool ExcluirVenda(string id)
        {
            var vendas = LerVendas();
            var vendaParaExcluir = vendas.FirstOrDefault(v => v.Id == id);

            if (vendaParaExcluir == null) return false;

            vendas.Remove(vendaParaExcluir);
            SalvarVendas(vendas);
            return true;
        }
    }
}
