using Microsoft.EntityFrameworkCore;
using web.Data;


namespace web
{
    public class PanicoMobileService : IPanicoMobile
    {
        private readonly ApplicationDbContext _context;

        public PanicoMobileService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PanicoMobile>> GetRegistroPanico()
        {
            try
            {
                return await _context.panicos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PanicoMobile> GetRegistroPanicoById(int id)
        {
            try
            {
                var panicos = await _context.panicos.FindAsync(id);
                return panicos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<IEnumerable<PanicoMobile>> GetPanicoUnico(string documentoUnico)
        {
            // Ajuste o retorno para uma lista de documentos
            return await _context.panicos
                .Where(d => d.idPessoa == documentoUnico)
                .ToListAsync();
        }

        public async Task SalvarRegistroPanico(PanicoMobile panicoMobile)
        {
            try
            {
                if (panicoMobile.Id == 0)
                {
                    await _context.panicos.AddAsync(panicoMobile);
                }
                else
                {
                    panicoMobile.Id = 0;
                    _context.panicos.AddAsync(panicoMobile);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Logar a exceção ou tratar de acordo com suas necessidades
                throw new Exception(
                    "Ocorreu um erro ao tentar salvar os dados. Verifique se os dados estão corretos e se não há conflitos.",
                    dbEx);
            }
            catch (Exception ex)
            {
                // Logar a exceção ou tratar de acordo com suas necessidades
                throw new Exception("Ocorreu um erro inesperado ao salvar os dados.", ex);
            }
        }

        public async Task DeleteRegistroPanico(int id)
        {
            try
            {
                var customer = await _context.panicos.FindAsync(id);
                if (customer != null)
                {
                    _context.panicos.Remove(customer);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception(
                    "Ocorreu um erro ao tentar excluir o registro. Verifique se ele está sendo utilizado em outra parte do sistema.",
                    dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }
    }
}