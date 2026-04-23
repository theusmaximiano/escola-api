using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {

        private readonly AppDbContext _context;

        public TurmaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Turma> AddAsync(Turma turma)
        {
            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();
            return turma;
        }

        public async Task<Turma?> DeleteAsync(int id)
        {
            var turma = await _context.Turmas
                .Where(x => x.Excluido == false && x.Id == id)
                .FirstOrDefaultAsync();

            if (turma == null)
            {
                return null;
            }
            turma.Excluido = true;
            _context.Turmas.Update(turma);
            await _context.SaveChangesAsync();

            return turma;
        }

        public async Task<List<Turma>> GetAllAsync()
        {
            return await _context.Turmas.Include(x => x.Curso).Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task<Turma?> GetByIdAsync(int id)
        {
            return await _context.Turmas.Include(x => x.Curso).Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Turma> UpdateAsync(Turma turma)
        {
            _context.Turmas.Update(turma);
            await _context.SaveChangesAsync();
            return turma;
        }
    }
}
