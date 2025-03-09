


namespace web
{
    public interface IBancoService
    {
        Task<IEnumerable<BancoConta>> GetRegistro();
        Task<BancoConta> GetRegistroById(int id);
        Task SalvarRegistro(BancoConta bancosConta);
        Task<BancoConta> DeleteRegistro(int id);
    }
}
