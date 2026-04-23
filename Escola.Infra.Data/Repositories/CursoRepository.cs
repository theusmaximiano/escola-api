using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Data.Repositories
{
 
    public class CursoRepository : ICursoRepository
    {

        private readonly AppDbContext _context;

        public CursoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<Curso?> DeleteAsync(int id)
        {
            var curso =  await _context.Cursos.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
            if (curso == null) 
            { 
                return null;
            }
            curso.Excluido = true;
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }

        public async Task<List<Curso>> GetAllAsync()
        {
            return await _context.Cursos.Where(x => x.Excluido == false).ToListAsync();

        }

        public async Task<Curso?> GetByIdAsync(int id)
        {
            return await _context.Cursos.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Curso> UpdateAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
    }
}
