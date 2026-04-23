using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task<Curso?> GetByIdAsync(int id);
        Task<List<Curso>> GetAllAsync();
        Task<Curso> AddAsync(Curso curso);
        Task<Curso> UpdateAsync(Curso curso);
        Task<Curso?> DeleteAsync(int id);

    }
}
