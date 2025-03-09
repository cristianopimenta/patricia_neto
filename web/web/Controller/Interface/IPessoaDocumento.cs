

namespace web
{
    public interface IPessoaDocumento
    {
        Task<IEnumerable<PessoaDocumento>> GetRegistro();
        Task<PessoaDocumento> GetRegistroById(int id);
        
        Task<IEnumerable<PessoaDocumento>> GetDocumentoUnico(string documentoUnico);
        Task SalvarRegistro(PessoaDocumento pessoadocumento);
        Task DeleteRegistro(int id);
    }
}
