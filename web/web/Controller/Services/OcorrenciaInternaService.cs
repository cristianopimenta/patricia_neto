using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace web
{
    public class OcorrenciaInternaService : IOcorrenciaInterna
    {
        private readonly ApplicationDbContext _context;
        public OcorrenciaInternaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.OcorrenciasInternas.FindAsync(id);
                if (customer != null)
                {
                    _context.OcorrenciasInternas.Remove(customer);
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


        public async Task<IEnumerable<OcorrenciaInternaModel>> GetRegistro()
        {
            try
            {
                return await _context.OcorrenciasInternas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<OcorrenciaInternaModel> GetRegistroById(int id)
        {
            try
            {
                var ocorrenciainterna = await _context.OcorrenciasInternas.FindAsync(id);
                return ocorrenciainterna;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(OcorrenciaInternaModel ocorrenciaInterna)
        {
            try
            {
                if (ocorrenciaInterna.Id == 0)
                {
                    await _context.OcorrenciasInternas.AddAsync(ocorrenciaInterna);
                }
                else
                {
                    _context.OcorrenciasInternas.Update(ocorrenciaInterna);
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