using backend.Models;
using System;

namespace backend.Services
{
    public class FinanceiroService
    {
        private const decimal TAXA_JUROS_DIARIA = 0.025m; 

        public CalculoJurosResponse Calcular(CalculoJurosRequest request)
        {
            var hoje = DateTime.Today;
            int diasAtraso = 0;

            if (hoje > request.DataVencimento.Date)
            {
                diasAtraso = (hoje - request.DataVencimento.Date).Days;
            }

            decimal valorJuros = request.ValorOriginal * TAXA_JUROS_DIARIA * diasAtraso;
            decimal valorTotal = request.ValorOriginal + valorJuros;

            return new CalculoJurosResponse
            {
                ValorOriginal = request.ValorOriginal,
                DataVencimento = request.DataVencimento.Date,
                DataCalculo = hoje,
                DiasAtraso = diasAtraso,
                ValorJuros = valorJuros,
                ValorTotal = valorTotal
            };
        }
    }
}
