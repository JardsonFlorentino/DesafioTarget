export interface Venda {
    id?: string;
    vendedor: string;
    valor: number;
}

export interface ComissaoResultado {
    nomeVendedor: string;
    totalVendas: number;
    totalComissao: number;
}
