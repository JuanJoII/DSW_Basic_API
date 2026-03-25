using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSW_Basic_API.DTOs;
using DSW_Basic_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web_API_Usuario.Data;
using Web_API_Usuario.Models;

namespace DSW_Basic_API.Services
{
    public class UserService : IUSerService
    {
        private readonly DbGeneralContext _context;

        public UserService(DbGeneralContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> ObtenerUsuarioPorId(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        public async Task<CreateUserDTO> CrearUsuario(CreateUserDTO dTO)
        {
            var nuevoUsuario = new Usuario
            {
                Nombre = dTO.Nombre,
                Apellido = dTO.Apellido,
                Correo = dTO.Correo,
                Username = dTO.Username
            };
            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();
            return new CreateUserDTO
            {
                Nombre = nuevoUsuario.Nombre,
                Apellido = nuevoUsuario.Apellido,
                Correo = nuevoUsuario.Correo,
                Username = nuevoUsuario.Username,
            };
        }
        public async Task<Usuario?> ActualizarUsuario(int id, Usuario usuarioActualizado)
        {
            var usuarioExistente = await _context.Usuarios.FindAsync(id);

            if (usuarioExistente == null)
            {
                return null; // Usuario no encontrado
            }

            usuarioExistente.Nombre = usuarioActualizado.Nombre;
            usuarioExistente.Apellido = usuarioActualizado.Apellido;
            usuarioExistente.Correo = usuarioActualizado.Correo;
            usuarioExistente.Username = usuarioActualizado.Username;
            await _context.SaveChangesAsync();
            return usuarioExistente;
        }


        public async Task<bool> EliminarUsuario(int id)
        {
            var usuarioEliminar = await _context.Usuarios.FindAsync(id);
            if (usuarioEliminar == null)
            {
                return false;
            }
            _context.Usuarios.Remove(usuarioEliminar);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}