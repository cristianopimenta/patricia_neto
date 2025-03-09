using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace web
{
    public class LocalidadeService : ILocalidade
    {
        private readonly ApplicationDbContext _context;
        public LocalidadeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.Localidades.FindAsync(id);
                if (customer != null)
                {
                    _context.Localidades.Remove(customer);
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


        public async Task<IEnumerable<LocalidadeModel>> GetRegistro()
        {
            try
            {
                return await _context.Localidades.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<LocalidadeModel> GetRegistroById(int id)
        {
            try
            {
                var localidade = await _context.Localidades.FindAsync(id);
                return localidade;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(LocalidadeModel localidade)
        {
            try
            {
                if (localidade.Id == 0)
                {
                    await _context.Localidades.AddAsync(localidade);
                }
                else
                {
                    _context.Localidades.Update(localidade);
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
    }
}