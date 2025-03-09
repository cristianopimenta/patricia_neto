using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using web.Data;


namespace web
{
    public class FornecedorService
    {
        private readonly ApplicationDbContext _context;

        public FornecedorService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todos os fornecedores
        public async Task<List<FornecedorModel>> GetFornecedoresAsync()
        {
            return await _context.Fonecedores.ToListAsync();
        }

        // Obter um fornecedor por ID
        public async Task<FornecedorModel> GetFornecedorByIdAsync(int id)
        {
            return await _context.Fonecedores.FindAsync(id);
        }

        // Criar um novo fornecedor
        public async Task CreateFornecedorAsync(FornecedorModel fornecedor)
        {
            _context.Fonecedores.Add(fornecedor);
            await _context.SaveChangesAsync();
        }

        // Atualizar um fornecedor existente
        public async Task UpdateFornecedorAsync(FornecedorModel fornecedor)
        {
            _context.Entry(fornecedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Excluir um fornecedor
        public async Task DeleteFornecedorAsync(int id)
        {
            var fornecedor = await _context.Fonecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fonecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}