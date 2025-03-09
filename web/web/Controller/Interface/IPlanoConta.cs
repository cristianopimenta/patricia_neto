


namespace web
{
    public interface IPlanoConta
    {
        Task<IEnumerable<PlanoContaModel>> GetRegistro();
        Task<PlanoContaModel> GetRegistroById(int id);
        Task SalvarRegistro(PlanoContaModel planoconta);
        Task SalvarRegistroEdicao(PlanoContaModel planoconta);
        Task DeleteRegistro(int id);
        Task<List<PlanoContaModel>> ObterPlanoContas();
       
    }
}

