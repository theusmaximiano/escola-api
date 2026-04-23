using Escola.Application.DTOs.Curso;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Escola.Application.Exceptions;

namespace Escola.Application.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoService(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }
        public async Task<CursoGetDTO> AddAsync(CursoPostDTO cursoPostDTO)
        {
            var curso = new Curso
            {
                Nome = cursoPostDTO.Nome,
                Descricao = cursoPostDTO.Descricao,
            };
            var createdCurso = await _cursoRepository.AddAsync(curso);
            return new CursoGetDTO
            {
                Id = createdCurso.Id,
                Nome = createdCurso.Nome,
                Descricao = createdCurso.Descricao,
            };
        }

        public async Task<CursoGetDTO> DeleteAsync(int id)
        {
            var deletedCurso = await _cursoRepository.DeleteAsync(id);
            if (deletedCurso == null)
            {
                throw new NotFoundException("Curso não encontrado");
            }
            return new CursoGetDTO
            {
                Id = deletedCurso.Id,
                Nome = deletedCurso.Nome,
                Descricao = deletedCurso.Descricao,
            };
        }

        public async Task<List<CursoGetDTO>> GetAllAsync()
        {
            var cursos = _cursoRepository.GetAllAsync();
            var cursoGetDTOs = new List<CursoGetDTO>();
            foreach (var curso in await cursos)
            {
                cursoGetDTOs.Add(new CursoGetDTO
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                });
            }
            return cursoGetDTOs;

        }

        public async Task<CursoGetDTO> GetByIdAsync(int id)
        {
            var curso = await _cursoRepository.GetByIdAsync(id);
            if (curso == null)
                throw new NotFoundException("Curso não encontrado");
            return new CursoGetDTO
            {
                Id = curso.Id,
                Nome = curso.Nome,
                Descricao = curso.Descricao,
            };  
        }

        public async Task<CursoGetDTO> UpdateAsync(CursoPutDTO cursoPutDTO)
        {
            
            var curso = await _cursoRepository.GetByIdAsync(cursoPutDTO.Id);
            if (curso == null)
                throw new NotFoundException("Curso não encontrado");

            curso.Nome = cursoPutDTO.Nome;
            curso.Descricao = cursoPutDTO.Descricao;

            var updatedCurso = await _cursoRepository.UpdateAsync(curso);
            return new CursoGetDTO
            {
                Id = updatedCurso.Id,
                Nome = updatedCurso.Nome,
                Descricao = updatedCurso.Descricao,
            };
        }
    }
}
