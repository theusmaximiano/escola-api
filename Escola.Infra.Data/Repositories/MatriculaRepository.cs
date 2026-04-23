using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {

        private readonly AppDbContext _context;

        public MatriculaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Matricula> AddAsync(Matricula matricula)
        {
            _context.Matriculas.Add(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }

        public async Task<Matricula?> DeleteAsync(int id)
        {
            var matricula = await _context.Matriculas.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
            if (matricula == null) 
            { 
                return null;
            }

            matricula.Excluido = true;
            _context.Matriculas.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;

        }

        public async Task<List<Matricula>> GetAllAsync()
        {
            return await _context.Matriculas.Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task<Matricula?> GetByIdAsync(int id)
        {
            return await _context.Matriculas.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Matricula> UpdateAsync(Matricula matricula)
        {
            _context.Matriculas.Update(matricula);
            await _context.SaveChangesAsync();
            return matricula;
        }
    }
}
