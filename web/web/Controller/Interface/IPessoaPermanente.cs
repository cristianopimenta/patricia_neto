


namespace web
{
    public interface IPessoaPermanente
    {
        Task<IEnumerable<PessoaPermanente>> GetRegistro();
        Task<PessoaPermanente> GetRegistroById(int id);
        Task SalvarRegistro(PessoaPermanente imovel);
        Task DeleteRegistro(int id);
    }
}

