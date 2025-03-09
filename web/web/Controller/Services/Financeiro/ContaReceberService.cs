using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.Controller.Interface;
using web.Data;



namespace web
{
    public class ContaReceberService : IContaReceber
    {
        private readonly ApplicationDbContext _context;

        public ContaReceberService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todas as contas a receber
        public async Task<List<ContaReceberModel>> GetContasReceberAsync()
        {
            return await _context.ContasReceber
                .Include(c => c.Pessoa)
                .Include(c => c.PlanoConta)
                .ToListAsync();
        }

        // Obter uma conta a receber por ID
        public async Task<ContaReceberModel> GetContaReceberByIdAsync(int id)
        {
            return await _context.ContasReceber
                .Include(c => c.Pessoa)
                .Include(c => c.PlanoConta)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Criar uma nova conta a receber
        public async Task CreateContaReceberAsync(ContaReceberModel contaReceber)
        {
            _context.ContasReceber.Add(contaReceber);
            await _context.SaveChangesAsync();
        }

        // Atualizar uma conta a receber
        public async Task UpdateContaReceberAsync(ContaReceberModel contaReceber)
        {
            _context.Entry(contaReceber).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Excluir uma conta a receber
        public async Task DeleteContaReceberAsync(int id)
        {
            var contaReceber = await _context.ContasReceber.FindAsync(id);
            if (contaReceber != null)
            {
                _context.ContasReceber.Remove(contaReceber);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ContaReceberModel>> GetContasReceberAsync(DateTime? dataVencimento, DateTime? dataPagamento, TipoLiquidacao? status)
        {
            // Inicia a query com todas as contas a pagar
            var query = _context.ContasReceber.AsQueryable();

            // Aplica os filtros, se fornecidos
            if (dataVencimento.HasValue)
            {
                query = query.Where(c => c.DataVencimento.HasValue && c.DataVencimento.Value.Date == dataVencimento.Value.Date);
            }

            if (dataPagamento.HasValue)
            {
                query = query.Where(c => c.DataRecebimento.HasValue && c.DataRecebimento.Value.Date == dataPagamento.Value.Date);
            }

            if (status.HasValue)
            {
                query = query.Where(c => c.StatusConta == status.Value);
            }

            // Retorna a lista de contas a pagar filtradas
            return await query.ToListAsync();
        }

        public async Task AddContaReceberAsync(ContaReceberModel conta)
        {
            _context.ContasReceber.Add(conta);
            await _context.SaveChangesAsync();
        }

        public async Task SaveContasReceberAsync(List<ContaReceberModel> contasReceber)
        {
            // Adicionar as contas a receber ao contexto do banco de dados
            _context.ContasReceber.AddRange(contasReceber);

            // Salvar as mudanças no banco de dados
            await _context.SaveChangesAsync();
        }
        public async Task<ContaReceberModel> ObterPlanoContaPorId(int id)
        {
            return await _context.ContasReceber
                .Include(p => p.PlanoConta) // Faz o carregamento da pessoas
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ContaReceberModel> ObterPessoaPorId(int id)
        {
            return await _context.ContasReceber
                .Include(p => p.Pessoa) // Faz o carregamento da pessoas
                .FirstOrDefaultAsync(p => p.Id == id);
        }

    }
}
