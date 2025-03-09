



namespace web
{
    public interface IPessoa
    {
        Task<IEnumerable<PessoaModel>> GetRegistro();
        Task<List<PessoaModel>> ObterPessoas();
        
        Task<IEnumerable<PessoaModel>> GetTipoMorador(string tipoMorador);

        Task<IEnumerable<object>> GetPessoasComImoveis();
        Task<PessoaModel> GetRegistroById(int id);
        Task SalvarRegistro(PessoaModel pessoa);
        Task DeleteRegistro(int id);
    }
}
