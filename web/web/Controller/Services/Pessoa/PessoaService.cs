using Microsoft.EntityFrameworkCore;
using web.Data;


namespace web
{
    public class PessoaService : IPessoa
    {
        private readonly ApplicationDbContext _contextPessoa;
        public PessoaService(ApplicationDbContext context)
        {
            _contextPessoa = context;
        }
        public async Task DeleteRegistro(int id)
        {
            var customer = await _contextPessoa.Pessoas.FindAsync(id);
            if (customer != null)
            {
                _contextPessoa.Remove(customer);
                await _contextPessoa.SaveChangesAsync();
            }
        }     

        public async Task<IEnumerable<PessoaModel>> GetRegistro()
        {
            try
            {
                var pessoas = await _contextPessoa.Pessoas.ToListAsync();
                Console.WriteLine($"Número de pessoas retornadas: {pessoas.Count()}");
                return pessoas;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter registros: {ex.Message}");
                return Enumerable.Empty<PessoaModel>();
            }
        }

        public async Task<IEnumerable<PessoaModel>> GetTipoMorador(string tipoMorador)
        {
            return await _contextPessoa.Pessoas
                .Where(d => d.Tipo == tipoMorador)
                .OrderBy(d => d.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetPessoasComImoveis()
        {
            try
            {
                var query = from pessoa in _contextPessoa.Pessoas
                    join pessoaPermanente in _contextPessoa.pessoasPermanentes
                        on pessoa.Id equals pessoaPermanente.id_pessoa
                    join imovel in _contextPessoa.Imoveis
                        on pessoaPermanente.id_imovel equals imovel.Id
                    select new
                    {
                        PessoaId = pessoa.Id,
                        PessoaNome = pessoa.Nome,
                        PessoaPermanenteIdPessoa = pessoaPermanente.id_pessoa,
                        Imovel = imovel // Retorna todas as colunas de Imovel
                    };

                var resultado = await query.Take(10).ToListAsync();

                Console.WriteLine($"Número de registros retornados: {resultado.Count()}");
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter registros: {ex.Message}");
                return Enumerable.Empty<object>();
            }
        }
        public async Task<PessoaModel> GetRegistroById(int id)
        {
            Console.WriteLine($"Buscando Pessoa com Id: {id}");
            var pessoa = await _contextPessoa.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            if (pessoa == null)
            {
                Console.WriteLine("Nenhuma pessoa encontrada.");
            }
            else
            {
                Console.WriteLine($"Pessoa encontrada: {pessoa.Nome}");
            }
            return pessoa;
            
        }

        public async Task SalvarRegistro(PessoaModel pessoa)
        {
            if (pessoa.Id == 0)
            {
                await _contextPessoa.Pessoas.AddAsync(pessoa);
            }
            else
            {
                _contextPessoa.Pessoas.Update(pessoa);
                
            }
            await _contextPessoa.SaveChangesAsync();
        }

        public async Task<List<PessoaModel>> ObterPessoas()
        {
            return await _contextPessoa.Pessoas.ToListAsync();
        }
    }
}
