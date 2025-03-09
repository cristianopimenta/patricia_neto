


namespace web
{
    public interface IImoveis
    {
        Task<IEnumerable<ImovelModel>> GetRegistro();
        Task<ImovelModel> GetRegistroById(int id);
        Task SalvarRegistro(ImovelModel imovel);
        Task SalvarRegistroEdicao(ImovelModel imovel);
        Task DeleteRegistro(int id);

        Task<List<ImovelModel>> GetImoveisAsync();
    }
}

