using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Escola.Infra.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Nota> AddAsync(Nota nota)
        {
            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<Nota?> DeleteAsync(int id)
        {
            var nota = await _context.Notas.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
            if (nota == null)
            {
                return null;
            }
            nota.Excluido = true;
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }

        public async Task<List<Nota>> GetAllAsync()
        {
            return await _context.Notas.Where(x => x.Excluido == false).ToListAsync();
        }

        public async Task<Nota?> GetByIdAsync(int id)
        {
            return await _context.Notas.Where(x => x.Excluido == false && x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Nota> UpdateAsync(Nota nota)
        {
            _context.Notas.Update(nota);
            await _context.SaveChangesAsync();
            return nota;
        }
    }
}
