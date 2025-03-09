

namespace web
{
    public interface IContaPagar
    {
       Task DeleteContaPagarAsync(int id);

        Task<List<ContaPagarModel>> GetContasPagarAsync(DateTime? dataVencimento, DateTime? dataPagamento, TipoLiquidacao? status);
        Task AddContaPagarAsync(ContaPagarModel conta);
        Task UpdateContaPagarAsync(ContaPagarModel conta);
        Task<ContaPagarModel> GetContaPagarByIdAsync(int id);

         Task SaveContasPagarAsync(List<ContaPagarModel> contasPagar);
    }
}
