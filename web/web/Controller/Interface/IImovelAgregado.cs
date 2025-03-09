


namespace web
{
    public interface IImovelAgregado
    {
        Task<IEnumerable<ImovelAgregadoModel>> GetRegistro();
        Task<ImovelAgregadoModel> GetRegistroById(int id);
        Task SalvarRegistro(ImovelAgregadoModel imovelAgregado);
        Task DeleteRegistro(int id);
    }
}

