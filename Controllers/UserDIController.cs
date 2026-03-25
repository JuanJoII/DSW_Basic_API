using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSW_Basic_API.DTOs;
using DSW_Basic_API.Filters;
using DSW_Basic_API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web_API_Usuario.Models;

namespace DSW_Basic_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserDIController : ControllerBase
    {
        private readonly IUSerService _userService;

        public UserDIController(IUSerService userService)
        {
            _userService = userService;
        }

        [HttpGet("Obtener_Usuarios_Con_Servicio")]
        [ServiceFilter(typeof(Filtrico))]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObtenerUsuarios()
        {
            var usuarios = await _userService.ObtenerUsuarios();
            if (usuarios == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No se encontraron usuarios.");
            }
            return StatusCode(StatusCodes.Status200OK, usuarios);
        }

        [HttpPost("Crear_Usuario_Con_Servicio")]
        public async Task<ActionResult<CreateUserDTO>> CrearUsuario(CreateUserDTO dTO)
        {
            var usuarioCreado = await _userService.CrearUsuario(dTO);
            return StatusCode(StatusCodes.Status201Created, usuarioCreado);
        }

    }
}