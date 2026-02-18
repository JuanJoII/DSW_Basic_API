using System;
using System.Collections.Generic;

namespace Web_API_Usuario.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Username { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
