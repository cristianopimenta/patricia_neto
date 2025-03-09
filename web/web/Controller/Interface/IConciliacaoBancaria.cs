using web.Data.Financeiro;

namespace web.Controller.Interface
{
    public interface IConciliacaoBancaria
    {
        Task<List<ConciliacaoBancariaModel>> ImportarXls(IFormFile file);
        Task<byte[]> ExportarXls();
    }
}
