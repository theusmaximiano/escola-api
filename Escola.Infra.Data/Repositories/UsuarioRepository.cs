using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios
                .Where(x => x.Excluido == false && x.Id == id)
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return null;
            }
            usuario.Excluido = true;
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> ExisteUsuarioAsync()
        {
            return await _context.Usuarios.AnyAsync(x => x.Excluido == false);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
