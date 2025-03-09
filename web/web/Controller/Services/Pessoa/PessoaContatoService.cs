using Microsoft.EntityFrameworkCore;
using web.Data;




namespace web;

public class PessoaContatoService : IPessoaContato
{
    private readonly ApplicationDbContext _context;

    public PessoaContatoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SalvarRegistroContato(PessoaContato pessoaContato)
    {
        try
        {
            if (pessoaContato.Id == 0)
            {
                await _context.pessoasContatos.AddAsync(pessoaContato);
            }
            else
            {
                pessoaContato.Id = 0;
                _context.pessoasContatos.AddAsync(pessoaContato);
            }

            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEx)
        {
            // Logar a exceção ou tratar de acordo com suas necessidades
            throw new Exception(
                "Ocorreu um erro ao tentar salvar os dados. Verifique se os dados estão corretos e se não há conflitos.",
                dbEx);
        }
        catch (Exception ex)
        {
            // Logar a exceção ou tratar de acordo com suas necessidades
            throw new Exception("Ocorreu um erro inesperado ao salvar os dados.", ex);
        }
    }

    public async Task DeleteRegistroContato(int id)
    {
        try
        {
            var customer = await _context.pessoasContatos.FindAsync(id);
            if (customer != null)
            {
                _context.pessoasContatos.Remove(customer);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Registro não encontrado.");
            }
        }
        catch (DbUpdateException dbEx)
        {
            throw new Exception(
                "Ocorreu um erro ao tentar excluir o registro. Verifique se ele está sendo utilizado em outra parte do sistema.",
                dbEx);
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro inesperado.", ex);
        }
    }

    public async Task<IEnumerable<PessoaContato>> GetRegistroContato()
    {
        try
        {
            return await _context.pessoasContatos.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Ocorreu um erro inesperado.", ex);
        }
    }

    async Task<PessoaContato> IPessoaContato.GetRegistroContatoById(int id)
    {
        try
        {
            var pessoaContato = await _context.pessoasContatos.FindAsync(id);
            return pessoaContato;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro inesperado.", ex);
        }
    }

    async Task<IEnumerable<PessoaContato>> IPessoaContato.GetContatoUnico(string documentoUnico)
    {
        // Ajuste o retorno para uma lista de documentos
        return await _context.pessoasContatos
            .Where(d => d.CpfPessoa == documentoUnico)
            .ToListAsync();
    }
}