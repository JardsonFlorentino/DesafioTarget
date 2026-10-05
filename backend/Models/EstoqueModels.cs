namespace backend.Models
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int EstoqueAtual { get; set; }
    }

    public class Movimentacao
    {
        // O Identificador Único exigido pelo Desafio!
        public Guid Id { get; set; } = Guid.NewGuid();
        public int CodigoProduto { get; set; }

        
        public string TipoMovimentacao { get; set; } = string.Empty;

        // Exigido pelo Desafio: "Descrição para identificar o tipo da movimentação"
        public string Descricao { get; set; } = string.Empty;

        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; } = DateTime.Now;
    }
}
