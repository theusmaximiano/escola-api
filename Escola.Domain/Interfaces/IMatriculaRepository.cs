using Escola.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task<Matricula?> GetByIdAsync(int id);
        Task<List<Matricula>> GetAllAsync();
        Task<Matricula> AddAsync(Matricula matricula);
        Task<Matricula> UpdateAsync(Matricula matricula);
        Task<Matricula?> DeleteAsync(int id);
    }
}
