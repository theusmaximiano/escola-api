using Escola.Application.DTOs.Nota;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Interfaces
{
    public interface INotaService
    {
        Task<NotaGetDTO> GetByIdAsync(int id);
        Task<List<NotaGetDTO>> GetAllAsync();
        Task<NotaGetDTO> AddAsync (NotaPostDTO dto);
        Task<NotaGetDTO> UpdateAsync (NotaPutDTO dto);
        Task<NotaGetDTO> DeleteAsync (int id);
    }
}
