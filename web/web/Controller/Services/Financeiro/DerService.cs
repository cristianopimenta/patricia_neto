
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.Data;




namespace web
{
    public class DerService
    {
        private readonly ApplicationDbContext _context;

        public DerService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para calcular o DER por período
        public async Task<DerResultado> CalcularDerAsync(DateTime inicio, DateTime fim)
        {
            var contasReceber = await _context.ContasReceber
                .Where(c => c.DataVencimento >= inicio && c.DataVencimento <= fim)
                .ToListAsync();

            var contasPagar = await _context.ContasPagar
                .Where(c => c.DataVencimento >= inicio && c.DataVencimento <= fim)
                .ToListAsync();

            var resultado = new DerResultado
            {
                TotalReceber = contasReceber.Sum(c => c.ValorRecebimento),
                TotalPagar = contasPagar.Sum(c => c.ValorPagamento),
                VencimentosAbertosReceber = contasReceber.Count(c => c.StatusConta == TipoLiquidacao.Aberto),
                VencimentosLiquidadosReceber = contasReceber.Count(c => c.StatusConta == TipoLiquidacao.Liquidado),
                VencimentosAbertosPagar = contasPagar.Count(c => c.StatusConta == TipoLiquidacao.Aberto),
                VencimentosLiquidadosPagar = contasPagar.Count(c => c.StatusConta == TipoLiquidacao.Liquidado)
            };

            return resultado;
        }

        // Método para calcular o DER mensal
        public async Task<List<DerResultado>> CalcularDerMensalAsync(int ano)
        {
            var resultados = new List<DerResultado>();

            for (int mes = 1; mes <= 12; mes++)
            {
                var inicio = new DateTime(ano, mes, 1);
                var fim = inicio.AddMonths(1).AddDays(-1);
                var resultado = await CalcularDerAsync(inicio, fim);
                resultados.Add(resultado);
            }

            return resultados;
        }

        // Método para calcular o DER semestral
        public async Task<List<DerResultado>> CalcularDerSemestralAsync(int ano)
        {
            var resultados = new List<DerResultado>();

            for (int semestre = 1; semestre <= 2; semestre++)
            {
                var inicio = new DateTime(ano, (semestre - 1) * 6 + 1, 1);
                var fim = inicio.AddMonths(6).AddDays(-1);
                var resultado = await CalcularDerAsync(inicio, fim);
                resultados.Add(resultado);
            }

            return resultados;
        }

        // Método para calcular o DER anual
        public async Task<DerResultado> CalcularDerAnualAsync(int ano)
        {
            var inicio = new DateTime(ano, 1, 1);
            var fim = new DateTime(ano, 12, 31);
            return await CalcularDerAsync(inicio, fim);
        }
    }

    // Classe para armazenar os resultados do DER
    public class DerResultado
    {
        public decimal TotalReceber { get; set; }
        public decimal TotalPagar { get; set; }
        public int VencimentosAbertosReceber { get; set; }
        public int VencimentosLiquidadosReceber { get; set; }
        public int VencimentosAbertosPagar { get; set; }
        public int VencimentosLiquidadosPagar { get; set; }
    }
}