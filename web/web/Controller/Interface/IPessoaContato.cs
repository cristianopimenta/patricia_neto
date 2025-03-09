


namespace web;

public interface IPessoaContato
{
    Task<IEnumerable<PessoaContato>> GetRegistroContato();
    Task<PessoaContato> GetRegistroContatoById(int id);

    Task<IEnumerable<PessoaContato>> GetContatoUnico(string documentoUnico);
    Task SalvarRegistroContato(PessoaContato pessoaContato);
    Task DeleteRegistroContato(int id);
}