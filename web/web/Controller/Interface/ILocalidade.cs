


namespace web
{
    public interface ILocalidade
    {
        Task<IEnumerable<LocalidadeModel>> GetRegistro();
        Task<LocalidadeModel> GetRegistroById(int id);
        Task SalvarRegistro(LocalidadeModel localidade);
        Task DeleteRegistro(int id);
    }
}

