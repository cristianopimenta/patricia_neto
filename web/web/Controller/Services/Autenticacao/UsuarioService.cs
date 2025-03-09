using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.Data;


namespace web.Controller.Services.Autenticacao
{
    public class UsuarioService
    {


        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext _context_usuario;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
            _context_usuario = context;
        }

        // Listar todos os usuaarios
        public async Task<List<UsuarioModel>> GetUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // Obter um usuario por ID
        public async Task<UsuarioModel> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        // Criar um novo usuario
        public async Task CreateUsuarioAsync(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        // Atualizar um usuario existente
        public async Task UpdateUsuarioAsync(UsuarioModel usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Excluir um usuario
        public async Task DeleteUsuarioAsync(int id)
        {
            var usuario
                = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<UsuarioModel>> AutenticarUsuarioAsync(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Email e senha não podem ser nulos ou vazios.");
            }

            try
            {
                // Supondo que a senha no banco de dados esteja hasheada
                var senhaHash = HashSenha(senha); // Implemente a função HashSenha conforme necessário

                var query = _context.Usuarios
                    .Where(c => c.Email == email && c.Senha == senhaHash);

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log da exceção (usando um logger, por exemplo)
                // Log.Error("Erro ao autenticar usuário", ex);
                throw; // Re-throw a exceção ou retorne uma lista vazia, dependendo do seu caso de uso
            }
        }

        private string HashSenha(string senha)
        {
            // Implemente a lógica de hash aqui (por exemplo, usando bcrypt)
            // Exemplo simplificado:
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        public async Task<IEnumerable<UsuarioModel>> GetUsuario()
        {
            return await _context_usuario.Usuarios               
                .OrderBy(d => d.Nome)
                .ToListAsync();
        }
    }
}