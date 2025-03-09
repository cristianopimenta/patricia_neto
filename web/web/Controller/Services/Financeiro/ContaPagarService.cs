using Microsoft.EntityFrameworkCore;
using web.Controller.Interface;
using web.Data;


namespace web
{
    public class ContaPagarService : IContaPagar
    {
        private readonly ApplicationDbContext _context;

        public ContaPagarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ContaPagarModel>> GetContasPagarAsync(DateTime? dataVencimento, DateTime? dataPagamento, TipoLiquidacao? status)
        {
            // Inicia a query com todas as contas a pagar
            var query = _context.ContasPagar.AsQueryable();

            // Aplica os filtros, se fornecidos
            if (dataVencimento.HasValue)
            {
                query = query.Where(c => c.DataVencimento.HasValue && c.DataVencimento.Value.Date == dataVencimento.Value.Date);
            }

            if (dataPagamento.HasValue)
            {
                query = query.Where(c => c.DataPagamento.HasValue && c.DataPagamento.Value.Date == dataPagamento.Value.Date);
            }

            if (status.HasValue)
            {
                query = query.Where(c => c.StatusConta == status.Value);
            }

            // Retorna a lista de contas a pagar filtradas
            return await query.ToListAsync();
        }

        public async Task AddContaPagarAsync(ContaPagarModel conta)
        {
            _context.ContasPagar.Add(conta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContaPagarAsync(ContaPagarModel conta)
        {
            _context.ContasPagar.Update(conta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContaPagarAsync(int id)
        {
            var conta = await _context.ContasPagar.FindAsync(id);
            if (conta != null)
            {
                _context.ContasPagar.Remove(conta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ContaPagarModel> GetContaPagarByIdAsync(int id)
        {
            return await _context.ContasPagar.FindAsync(id);
        }

        public async Task SaveContasPagarAsync(List<ContaPagarModel> contasPagar)
        {
            // Adicionar as contas a receber ao contexto do banco de dados
            _context.ContasPagar.AddRange(contasPagar);

            // Salvar as mudanças no banco de dados
            await _context.SaveChangesAsync();
        }

        public async Task<ContaPagarModel> ObterPlanoContaPorId(int id)
        {
            return await _context.ContasPagar
                .Include(p => p.PlanoConta) // Faz o carregamento da pessoas
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}