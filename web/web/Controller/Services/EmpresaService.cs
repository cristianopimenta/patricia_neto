using Microsoft.EntityFrameworkCore;
using web.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace web
{
    public class EmpresaService : IEmpresa
    {
        private readonly ApplicationDbContext _context;
        public EmpresaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _context.Empresas.FindAsync(id);
                if (customer != null)
                {
                    _context.Empresas.Remove(customer);
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

        public async Task<IEnumerable<EmpresaModel>> GetCNPJ(string documentoUnico)
        {
            // Ajuste o retorno para uma lista de documentos
            return await _context.Empresas
                .Where(d => d.CNPJ == documentoUnico)
                .ToListAsync();
        }

        public async Task<List<EmpresaModel>> ObterEmpresa()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<IEnumerable<EmpresaModel>> GetEmail(string email)
        {
            // Ajuste o retorno para uma lista de documentos
            return await _context.Empresas
                .Where(d => d.Email == email)
                .ToListAsync();
        }

        public async Task<List<EmpresaModel>> ObterEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<EmpresaModel> ObterEmpresaPorId(int id)
        {
            return await _context.Empresas              
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IEnumerable<EmpresaModel>> GetRegistro()
        {
            try
            {
                return await _context.Empresas.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<EmpresaModel> GetRegistroById(int id)
        {
            try
            {
                var empresa = await _context.Empresas.FindAsync(id);
                return empresa;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(EmpresaModel empresa)
        {
            try
            {
                if (empresa.Id == 0)
                {
                    await _context.Empresas.AddAsync(empresa);
                }
                else
                {
                    _context.Empresas.Update(empresa);
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

        public async Task<bool> ExisteEmpresaCadastrada()
        {
            return await _context.Empresas.AnyAsync();
        }
    }
}