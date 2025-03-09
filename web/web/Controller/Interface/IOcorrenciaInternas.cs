


namespace web
{
    public interface IOcorrenciaInterna
    {
        Task<IEnumerable<OcorrenciaInternaModel>> GetRegistro();
        Task<OcorrenciaInternaModel> GetRegistroById(int id);
        Task SalvarRegistro(OcorrenciaInternaModel ocorrenciaInterna);
        Task DeleteRegistro(int id);
    }
}

