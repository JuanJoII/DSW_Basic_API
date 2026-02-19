using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_Usuario.Models;

namespace Web_API_Usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DbUsuarioContext _context;
        public UsuarioController(DbUsuarioContext context)
        {
            _context = context;

        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsuario()
        {
            var usuarios = await _context.Usuario.ToListAsync();
            if (usuarios != null)
            {
                return Ok(StatusCode(StatusCodes.Status200OK, usuarios));
            }
            return NotFound(StatusCode(StatusCodes.Status404NotFound, "No hay usuarios registrados"));
        }

        [HttpPost("Guardar")]
        public async Task<ActionResult<Usuario>> GuardarUsuario(Usuario usuario)
        {
            usuario.FechaCreacion = DateTime.Now;
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, usuario);
        }

        [HttpGet("Buscar/{id}")]
        public async Task<ActionResult> BuscarPorId(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado"));
            }
            return Ok(StatusCode(StatusCodes.Status200OK, usuario));
        }

        [HttpDelete("Eliminar/{id}")]
        public async Task<ActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado"));
            }
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok(StatusCode(StatusCodes.Status200OK, usuario));
        }

        [HttpPut("Actualizar/{id}")]
        public async Task<ActionResult> ActualizarUsuario(int id, Usuario usuarioActualizado)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound(StatusCode(StatusCodes.Status404NotFound, "Usuario no encontrado"));
            }
            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Apellido = usuarioActualizado.Apellido;
            usuario.Correo = usuarioActualizado.Correo;
            usuario.Username = usuarioActualizado.Username;
            await _context.SaveChangesAsync();
            return Ok(StatusCode(StatusCodes.Status200OK, usuario));
        }

    }
}