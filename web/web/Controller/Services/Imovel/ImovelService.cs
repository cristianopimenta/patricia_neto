using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace web
{
    public class ImovelService : IImoveis
    {
        private readonly ApplicationDbContext _context;
        public ImovelService(ApplicationDbContext context)
        {
            _context = context;
        }
             

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.Imoveis.FindAsync(id);
                if (customer != null)
                {
                    _context.Imoveis.Remove(customer);
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

        public async Task<List<ImovelModel>> GetImoveisAsync()
        {
            // Ajuste o retorno para uma lista de imoveis 
            return await _context.Imoveis
            .Where(imovel => imovel.StatusImovel == StatusImovel.Liberado)
            .ToListAsync();

        }

        public async Task<IEnumerable<ImovelModel>> GetRegistro()
        {
            try
            {
                return await _context.Imoveis.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<ImovelModel> GetRegistroById(int id)
        {
            try
            {
                var imoveis = await _context.Imoveis.FindAsync(id);
                return imoveis;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(ImovelModel imovel)
        {
            try
            {
                if (imovel.Id == 0)
                {
                    await _context.Imoveis.AddAsync(imovel);
                }
                else
                {
                    _context.Imoveis.Update(imovel);
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

        public async Task SalvarRegistroEdicao(ImovelModel imovel)
        {
            _context.Entry(imovel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}