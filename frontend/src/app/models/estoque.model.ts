export interface Produto {
  codigoProduto: number;
  descricaoProduto: string;
  estoqueAtual: number;
}

export interface Movimentacao {
  id?: string;
  codigoProduto: number;
  tipoMovimentacao: string;
  descricao: string;
  quantidade: number;
  dataMovimentacao?: string;
}
