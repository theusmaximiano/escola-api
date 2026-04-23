using Escola.Application.DTOs.Nota;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Application.Services
{
    namespace Escola.Application.Services
    {
        public class NotaService : INotaService
        {
            private readonly INotaRepository _notaRepository;
            private readonly IMatriculaRepository _matriculaRepository;

            public NotaService(INotaRepository notaRepository)
            {
                _notaRepository = notaRepository;
            }

            public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
            {
                if (await _matriculaRepository.GetByIdAsync(notaPostDTO.MatriculaId) == null)
                throw new NotFoundException("Matrícula não encontrada.");

                var nota = new Nota
                {
                    MatriculaId = notaPostDTO.MatriculaId,
                    ValorNota = notaPostDTO.ValorNota,
                    Aprovado = notaPostDTO.ValorNota >= 60,
                    DataNota = DateTime.Now
                };

                var createdNota = await _notaRepository.AddAsync(nota);

                return new NotaGetDTO
                {
                    Id = createdNota.Id,
                    MatriculaId = createdNota.MatriculaId,
                    ValorNota = createdNota.ValorNota,
                    Aprovado = createdNota.Aprovado,
                    DataNota = createdNota.DataNota
                };
            }

            public async Task<NotaGetDTO> DeleteAsync(int id)
            {
                var deletedNota = await _notaRepository.DeleteAsync(id);
                if (deletedNota == null)
                    throw new NotFoundException("Nota não encontrada.");

                return new NotaGetDTO
                {
                    Id = deletedNota.Id,
                    MatriculaId = deletedNota.MatriculaId,
                    ValorNota = deletedNota.ValorNota,
                    Aprovado = deletedNota.Aprovado,
                    DataNota = deletedNota.DataNota
                };
            }

            public async Task<List<NotaGetDTO>> GetAllAsync()
            {
                var notas = await _notaRepository.GetAllAsync();

                var notaGetDTOs = new List<NotaGetDTO>();

                notaGetDTOs.AddRange(notas.Select(n => new NotaGetDTO
                {
                    Id = n.Id,
                    MatriculaId = n.MatriculaId,
                    ValorNota = n.ValorNota,
                    Aprovado = n.Aprovado,
                    DataNota = n.DataNota
                }));

                return notaGetDTOs;
            }

            public async Task<NotaGetDTO> GetByIdAsync(int id)
            {
                var nota = await _notaRepository.GetByIdAsync(id);
                if (nota == null)
                    throw new NotFoundException("Nota não encontrada.");

                return new NotaGetDTO
                {
                    Id = nota.Id,
                    MatriculaId = nota.MatriculaId,
                    ValorNota = nota.ValorNota,
                    Aprovado = nota.Aprovado,
                    DataNota = nota.DataNota
                };
            }

            public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
            {
                var existingNota = await _notaRepository.GetByIdAsync(notaPutDTO.Id);

                if (existingNota == null)
                    throw new NotFoundException("Nota não encontrada.");

                if(notaPutDTO.MatriculaId != existingNota.MatriculaId)
                {
                    if (await _matriculaRepository.GetByIdAsync(notaPutDTO.MatriculaId) == null)
                        throw new NotFoundException("Matrícula não encontrada.");
                    existingNota.MatriculaId = notaPutDTO.MatriculaId;
                }

                existingNota.ValorNota = notaPutDTO.ValorNota;
                existingNota.Aprovado = notaPutDTO.ValorNota >= 60;
                var updatedNota = await _notaRepository.UpdateAsync(existingNota);
                return new NotaGetDTO
                {
                    Id = updatedNota.Id,
                    MatriculaId = updatedNota.MatriculaId,
                    ValorNota = updatedNota.ValorNota,
                    Aprovado = updatedNota.Aprovado,
                    DataNota = updatedNota.DataNota
                };
            }
        }
    }
}