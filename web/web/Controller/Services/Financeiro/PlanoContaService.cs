using Microsoft.EntityFrameworkCore;
using web.Data;

using static System.Runtime.InteropServices.JavaScript.JSType;



namespace web
{
    public class PlanoContaService : IPlanoConta
    {
        private readonly ApplicationDbContext _context;
        public PlanoContaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.PlanoContas.FindAsync(id);
                if (customer != null)
                {
                    _context.PlanoContas.Remove(customer);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir o registro. Verifique se ele está sendo utilizado em outra parte do sistema.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }


        public async Task<IEnumerable<PlanoContaModel>> GetRegistro()
        {
            try
            {
                return await _context.PlanoContas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PlanoContaModel> GetRegistroById(int id)
        {
            try
            {
                var planoconta = await _context.PlanoContas.FindAsync(id);
                return planoconta;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<List<PlanoContaModel>> ObterPlanoContas()
        {
        
            return await _context.PlanoContas.ToListAsync();
        
        }
       

        public async Task SalvarRegistro(PlanoContaModel planoconta)
        {
            try
            {
                if (planoconta.Id == 0)
                {
                    await _context.PlanoContas.AddAsync(planoconta);
                }
                else
                {
                    _context.PlanoContas.Update(planoconta);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Logar a exceção ou tratar de acordo com suas necessidades
                throw new Exception("Ocorreu um erro ao tentar salvar os dados. Verifique se os dados estão corretos e se não há conflitos.", dbEx);
            }
            catch (Exception ex)
            {
                // Logar a exceção ou tratar de acordo com suas necessidades
                throw new Exception("Ocorreu um erro inesperado ao salvar os dados.", ex);
            }
        }

        public async Task SalvarRegistroEdicao(PlanoContaModel planoconta)
        {
            _context.Entry(planoconta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}