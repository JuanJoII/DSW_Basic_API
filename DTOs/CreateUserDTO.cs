using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSW_Basic_API.DTOs
{
    public class CreateUserDTO
    {
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Username { get; set; }
    }
}