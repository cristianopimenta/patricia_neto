

namespace web
{
    public interface IPessoaEnderecos
    {
          
        Task<IEnumerable<PessoaEndereco>> GetRegistroEndereco();
        Task<PessoaEndereco> GetRegistroEnderecoById(int id);
        Task<IEnumerable<PessoaEndereco>> GetEnderecoUnico(string documentoUnico);
        Task SalvarRegistroEndereco(PessoaEndereco pessoaEndereco);
        Task DeleteRegistroEndereco(int id);

    }
}

