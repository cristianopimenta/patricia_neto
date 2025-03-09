using Microsoft.EntityFrameworkCore;
using web.Data;


namespace web
{
    public class PetService : IPet
    {
        private readonly ApplicationDbContext _pet;
        public PetService(ApplicationDbContext context)
        {
            _pet = context;
        }

        public async Task DeleteRegistro(int id)
        {
            try
            {
                var customer = await _pet.AnimaisEstimacao.FindAsync(id);
                if (customer != null)
                {
                    _pet.AnimaisEstimacao.Remove(customer);
                    await _pet.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("Registro não encontrado.");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception("Ocorreu um erro ao tentar excluir o registro. Verifique se ele está sendo utilizado em outra parte do sistema.", dbEx);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }


        public async Task<IEnumerable<PetModel>> GetRegistro()
        {
            try
            {
                return await _pet.AnimaisEstimacao.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task<PetModel> GetRegistroById(int id)
        {
            try
            {
                var pets = await _pet.AnimaisEstimacao.FindAsync(id);
                return pets;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro inesperado.", ex);
            }
        }

        public async Task SalvarRegistro(PetModel pet)
        {
            try
            {
                if (pet.Id == 0)
                {
                    await _pet.AnimaisEstimacao.AddAsync(pet);
                }
                else
                {
                    _pet.AnimaisEstimacao.Update(pet);
                }

                await _pet.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                // Logar a exceção ou tratar de acordo com suas necessidades
                throw new Exception("Ocorreu um erro ao tentar salvar os dados. Verifique se os dados estão corretos e se não há conflitos.", dbEx);
            }
            catch (Exception ex)
            {
                // Logar a exceção ou tratar de acordo com suas necessidades
                throw new Exception("Ocorreu um erro inesperado ao salvar os dados.", ex);
            }
        }
    }
}