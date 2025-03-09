using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace web
{
    public class PessoaVeiculoService : IPessoaVeiculo
    {
        private readonly ApplicationDbContext _context;

        public PessoaVeiculoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PessoaVeiculo>> GetRegistroVeiculo()
        {
            try
            {
                return await _context.pessoasVeiculos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PessoaVeiculo> GetRegistroVeiculoById(int id)
        {
            try
            {
                var pessoaVeiculo = await _context.pessoasVeiculos.FindAsync(id);
                return pessoaVeiculo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<IEnumerable<PessoaVeiculo>> GetVeiculoUnico(string documentoUnico)
        {
            // Ajuste o retorno para uma lista de documentos
            return await _context.pessoasVeiculos
                .Where(d => d.CpfPessoa == documentoUnico)
                .ToListAsync();
        }

        public async Task SalvarRegistroVeiculo(PessoaVeiculo pessoaVeiculo)
        {
            try
            {
                if (pessoaVeiculo.Id == 0)
                {
                    await _context.pessoasVeiculos.AddAsync(pessoaVeiculo);
                }
                else
                {
                    pessoaVeiculo.Id = 0;
                    _context.pessoasVeiculos.AddAsync(pessoaVeiculo);
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

        public async Task DeleteRegistroVeiculo(int id)
        {
            try
            {
                var customer = await _context.pessoasVeiculos.FindAsync(id);
                if (customer != null)
                {
                    _context.pessoasVeiculos.Remove(customer);
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