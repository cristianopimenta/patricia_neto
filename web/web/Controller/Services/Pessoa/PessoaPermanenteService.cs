using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;





namespace web
{
    public class PessoaPermanenteService : IPessoaPermanente
    {
        private readonly ApplicationDbContext _context_imvPermanente;
        public PessoaPermanenteService(ApplicationDbContext context)
        {
            _context_imvPermanente = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context_imvPermanente.pessoasPermanentes.FindAsync(id);
                if (customer != null)
                {
                    _context_imvPermanente.pessoasPermanentes.Remove(customer);
                    await _context_imvPermanente.SaveChangesAsync();
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


        public async Task<IEnumerable<PessoaPermanente>> GetRegistro()
        {
            try
            {
                return await _context_imvPermanente.pessoasPermanentes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PessoaPermanente> GetRegistroById(int id)
        {
            try
            {
                var imovelpermanente = await _context_imvPermanente.pessoasPermanentes.FindAsync(id);
                return imovelpermanente;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(PessoaPermanente imovelPermanente)
        {
            try
            {
                if (imovelPermanente.id == 0)
                {
                    await _context_imvPermanente.pessoasPermanentes.AddAsync(imovelPermanente);
                }
                else
                {
                    _context_imvPermanente.pessoasPermanentes.Update(imovelPermanente);
                }

                await _context_imvPermanente.SaveChangesAsync();
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