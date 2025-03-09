using Microsoft.EntityFrameworkCore;
using web.Data;


namespace web
{
    public class PessoaEnderecoService : IPessoaEnderecos
    {
        private readonly ApplicationDbContext _context;

        public PessoaEnderecoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PessoaEndereco>> GetRegistroEndereco()
        {
            try
            {
                return await _context.pessoasEnderecos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PessoaEndereco> GetRegistroEnderecoById(int id)
        {
            try
            {
                var pessoaEndereco = await _context.pessoasEnderecos.FindAsync(id);
                return pessoaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<IEnumerable<PessoaEndereco>> GetEnderecoUnico(string documentoUnico)
        {
            // Ajuste o retorno para uma lista de documentos
            return await _context.pessoasEnderecos
                .Where(d => d.CpfPessoa == documentoUnico)
                .ToListAsync();
        }

        public async Task SalvarRegistroEndereco(PessoaEndereco pessoaEndereco)
        {
            try
            {
                if (pessoaEndereco.Id == 0)
                {
                    await _context.pessoasEnderecos.AddAsync(pessoaEndereco);
                }
                else
                {
                    pessoaEndereco.Id = 0;
                    _context.pessoasEnderecos.AddAsync(pessoaEndereco);
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

        public async Task DeleteRegistroEndereco(int id)
        {
            try
            {
                var customer = await _context.pessoasEnderecos.FindAsync(id);
                if (customer != null)
                {
                    _context.pessoasEnderecos.Remove(customer);
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

