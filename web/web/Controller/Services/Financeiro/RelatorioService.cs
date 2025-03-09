using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.Data;



namespace web
{

    public class RelatorioService
    {
        private readonly ApplicationDbContext _context;

        public RelatorioService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para buscar contas a receber com base nos filtros
        public async Task<List<ContaReceberModel>> BuscarContasReceberAsync(DateTime inicio, DateTime fim, TipoLiquidacao? status)
        {
            var query = _context.ContasReceber
                .Where(c => c.DataVencimento >= inicio && c.DataVencimento <= fim);

            if (status.HasValue)
            {
                query = query.Where(c => c.StatusConta == status.Value);
            }

            return await query.ToListAsync();
        }

        // Método para buscar contas a pagar com base nos filtros
        public async Task<List<ContaPagarModel>> BuscarContasPagarAsync(DateTime inicio, DateTime fim, TipoLiquidacao? status)
        {
            var query = _context.ContasPagar
                .Where(c => c.DataVencimento >= inicio && c.DataVencimento <= fim);

            if (status.HasValue)
            {
                query = query.Where(c => c.StatusConta == status.Value);
            }

            return await query.ToListAsync();
        }
    }
}
