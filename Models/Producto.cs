using System;
using System.Collections.Generic;

namespace Web_API_Usuario.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public string Categoria { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }
}
