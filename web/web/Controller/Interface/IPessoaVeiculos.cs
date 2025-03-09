


namespace web
{
    public interface IPessoaVeiculo
    {
        Task<IEnumerable<PessoaVeiculo>> GetRegistroVeiculo();
        Task<PessoaVeiculo> GetRegistroVeiculoById(int id);
        Task<IEnumerable<PessoaVeiculo>> GetVeiculoUnico(string documentoUnico);
        Task SalvarRegistroVeiculo(PessoaVeiculo pessoaContato);
        Task DeleteRegistroVeiculo(int id);
        
    }
}

