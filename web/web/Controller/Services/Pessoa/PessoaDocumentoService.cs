using Microsoft.EntityFrameworkCore;
using web.Data;




namespace web
{
    public class PessoaDocumentoService : IPessoaDocumento
    {
        private readonly ApplicationDbContext _context;
        public PessoaDocumentoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.PessoaDocumentos.FindAsync(id);
                if (customer != null)
                {
                    _context.PessoaDocumentos.Remove(customer);
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


        public async Task<IEnumerable<PessoaDocumento>> GetRegistro()
        {
            try
            {
                return await _context.PessoaDocumentos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PessoaDocumento> GetRegistroById(int id)
        {
            try
            {
                var pessoaDocumento = await _context.PessoaDocumentos.FindAsync(id);
                return pessoaDocumento;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<IEnumerable<PessoaDocumento>> GetDocumentoUnico(string documentoUnico)
        {
            // Ajuste o retorno para uma lista de documentos
            return await _context.PessoaDocumentos
                .Where(d => d.CpfPessoa == documentoUnico)
                .ToListAsync();
        }

        public async Task SalvarRegistro(PessoaDocumento pessoadocumento)
        {
            try
            {
                if (pessoadocumento.Id == 0)
                {
                    await _context.PessoaDocumentos.AddAsync(pessoadocumento);
                }
                else
                {
                    pessoadocumento.Id = 0;
                    _context.PessoaDocumentos.AddAsync(pessoadocumento);
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

