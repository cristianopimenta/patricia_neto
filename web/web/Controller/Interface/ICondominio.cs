


namespace web
{
    public interface ICondominio
    {
        Task<IEnumerable<CondominioModel>> GetRegistro();
        Task<CondominioModel> GetRegistroById(int id);
        Task SalvarRegistro(CondominioModel pessoa);
        Task DeleteRegistro(int id);
    }
}
