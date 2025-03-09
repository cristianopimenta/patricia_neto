

namespace web
{
    public interface IBanco
    {
        Task<IEnumerable<BancoModel>> GetRegistro();
        Task<BancoModel> GetRegistroById(int id);
        Task SalvarRegistro(BancoModel banco);
        Task DeletaRegistro(int id);
    }
}