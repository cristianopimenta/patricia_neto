using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace web
{
    public class ImovelAgregadoService : IImovelAgregado
    {
        private readonly ApplicationDbContext _context;
        public ImovelAgregadoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.ImoveisAgradados.FindAsync(id);
                if (customer != null)
                {
                    _context.ImoveisAgradados.Remove(customer);
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


        public async Task<IEnumerable<ImovelAgregadoModel>> GetRegistro()
        {
            try
            {
                return await _context.ImoveisAgradados.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<ImovelAgregadoModel> GetRegistroById(int id)
        {
            try
            {
                var imovelAgregado = await _context.ImoveisAgradados.FindAsync(id);
                return imovelAgregado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(ImovelAgregadoModel imovelAgregado)
        {
            try
            {
                if (imovelAgregado.Id == 0)
                {
                    await _context.ImoveisAgradados.AddAsync(imovelAgregado);
                }
                else
                {
                    _context.ImoveisAgradados.Update(imovelAgregado);
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