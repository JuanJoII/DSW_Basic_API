using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSW_Basic_API.DTOs;
using Web_API_Usuario.Models;

namespace DSW_Basic_API.Interfaces
{
    public interface IUSerService
    {
        // Definir los métodos que el servicio de usuario debe implementar

        //GET: Todos los usuarios
        Task<IEnumerable<Usuario>> ObtenerUsuarios();

        //GET: Usuario por ID
        Task<Usuario?> ObtenerUsuarioPorId(int id);

        //POST: Crear un nuevo usuario
        Task<CreateUserDTO> CrearUsuario(CreateUserDTO nuevoUsuario);

        //PUT: Actualizar un usuario existente
        Task<Usuario?> ActualizarUsuario(int id, Usuario usuarioActualizado);

        //DELETE: Eliminar un usuario por ID
        Task<bool> EliminarUsuario(int id);
    }
}