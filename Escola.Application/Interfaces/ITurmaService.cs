using Escola.Application.DTOs.Turma;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO);
        Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO);
        Task<TurmaGetDTO> DeleteAsync(int id);
        Task<TurmaGetDetailDTO> GetByIdAsync(int id);
        Task<List<TurmaGetDetailDTO>> GetAllAsync();
    }
}
