



namespace web
{
    public interface IPanicoMobile
    {
        Task<IEnumerable<PanicoMobile>> GetRegistroPanico();
        Task<PanicoMobile> GetRegistroPanicoById(int id);
        Task<IEnumerable<PanicoMobile>> GetPanicoUnico(string documentoUnico);
        Task SalvarRegistroPanico(PanicoMobile panicoMobile);
        Task DeleteRegistroPanico(int id);
        
    }
}

