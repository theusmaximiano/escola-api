using Escola.Application.DTOs.Usuario;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Escola.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioGetDTO> AddAsync(UsuarioPostDTO usuarioPostDTO)
        {
            using var hmac = new HMACSHA512();
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPostDTO.Senha));
            byte[] passwordSalt = hmac.Key;

            var existeUsuario = await _usuarioRepository.ExisteUsuarioAsync();

            var usuario = new Usuario
            {
                Nome = usuarioPostDTO.Nome,
                Email = usuarioPostDTO.Email,
                Excluido = false,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Perfil = existeUsuario ? "Aluno" : "Administrador"
            };



            var createdUsuario = await _usuarioRepository.AddAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = createdUsuario.Id,
                Nome = createdUsuario.Nome,
                Email = createdUsuario.Email,
                Perfil = createdUsuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> DeleteAsync(int id)
        {
            var deletedUsuario = await _usuarioRepository.DeleteAsync(id);  
            if (deletedUsuario == null)
                return null;
            return new UsuarioGetDTO
            {
                Id = deletedUsuario.Id,
                Nome = deletedUsuario.Nome,
                Email = deletedUsuario.Email,
                Perfil= deletedUsuario.Perfil
            };
        }

        public async Task<bool> ExisteUsuarioAsync()
        {
            return await _usuarioRepository.ExisteUsuarioAsync();
        }

        public async Task<List<UsuarioGetDTO>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var usuarioDtos = new List<UsuarioGetDTO>();
            usuarioDtos.AddRange(usuarios.Select(u => new UsuarioGetDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email
            }));
            return usuarioDtos;
        }

        public async Task<UsuarioGetDTO> GetByIdAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return null;
            return new UsuarioGetDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }

        public async Task<UsuarioGetDTO> UpdateAsync(int usuarioId, UsuarioPutDTO usuarioPutDTO)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);
            if (usuario == null)
                return null;
            usuario.Nome = usuarioPutDTO.Nome;
            usuario.Email = usuarioPutDTO.Email;
            var updatedUsuario = await _usuarioRepository.UpdateAsync(usuario);
            return new UsuarioGetDTO
            {
                Id = updatedUsuario.Id,
                Nome = updatedUsuario.Nome,
                Email = updatedUsuario.Email,
                Perfil = updatedUsuario.Perfil
            };
        }
    }
}
