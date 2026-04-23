using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma?> GetByIdAsync(int id);
        Task<List<Turma>> GetAllAsync();
        Task<Turma> AddAsync(Turma turma);
        Task<Turma> UpdateAsync(Turma turma);
        Task<Turma?> DeleteAsync(int id);
    }
}
