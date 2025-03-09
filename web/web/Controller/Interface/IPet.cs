


namespace web
{
    public interface IPet
    {
        Task<IEnumerable<PetModel>> GetRegistro();
        Task<PetModel> GetRegistroById(int id);
        Task SalvarRegistro(PetModel pet);
        Task DeleteRegistro(int id);
    }
}

