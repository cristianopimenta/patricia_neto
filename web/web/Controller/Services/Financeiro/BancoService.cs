using Microsoft.EntityFrameworkCore;
using web.Data;


namespace web
{
    public class BancoService : IBanco
    {
        private readonly ApplicationDbContext _context;
        public BancoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeletaRegistro(int id)
        {
            var customer = await _context.Bancos.FindAsync(id);
            if (customer != null)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BancoModel>> GetRegistro()
        {
            return await _context.Bancos.ToListAsync();
        }

        public async Task<BancoModel> GetRegistroById(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            return banco;
        }

        public async Task SalvarRegistro(BancoModel banco)
        {
            if (banco.Id == 0)
            {
                await _context.Bancos.AddAsync(banco);
            }
            else
            {
                _context.Bancos.Update(banco);
                
            }
            await _context.SaveChangesAsync();
        }
    }
}
