namespace web.Controller.Interface
{
    public interface IContaReceber
    {
        Task DeleteContaReceberAsync(int id);

        Task<List<ContaReceberModel>> GetContasReceberAsync(DateTime? dataVencimento, DateTime? dataPagamento, TipoLiquidacao? status);
        Task AddContaReceberAsync(ContaReceberModel conta);
        Task UpdateContaReceberAsync(ContaReceberModel conta);

        Task<ContaReceberModel> GetContaReceberByIdAsync(int id);
        Task CreateContaReceberAsync(ContaReceberModel contaReceber);
        Task SaveContasReceberAsync(List<ContaReceberModel> contasReceber);
   
    }
}
