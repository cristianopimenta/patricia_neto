


namespace web
{
    public interface IEmpresa
    {
        Task<bool> ExisteEmpresaCadastrada();
        Task<IEnumerable<EmpresaModel>> GetRegistro();
        Task<EmpresaModel> GetRegistroById(int id);
        Task SalvarRegistro(EmpresaModel empresa);
        Task DeleteRegistro(int id);
        
        Task<IEnumerable<EmpresaModel>> GetCNPJ(string documentoUnico);
        Task<IEnumerable<EmpresaModel>> GetEmail(string email);

        Task<List<EmpresaModel>> ObterEmpresas();

        Task<EmpresaModel> ObterEmpresaPorId(int id);
    }
}

