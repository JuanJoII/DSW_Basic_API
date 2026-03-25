using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSW_Basic_API.DTOs
{
    public class CreateProductDTO
    {
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; } = null!;
    }
}