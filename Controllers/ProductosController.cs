using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Web_API_Usuario.Data;
using Web_API_Usuario.Models;

namespace DSW_Basic_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly DbGeneralContext _context;
        public ProductosController(DbGeneralContext context)
        {
            _context = context;
        }

        [HttpGet("Productos")]
        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerProductos()
        {
            var productos = await _context.Productos.ToListAsync();
            if (productos != null)
            {
                return Ok(StatusCode(StatusCodes.Status200OK, productos));
            }
            return NotFound(StatusCode(StatusCodes.Status404NotFound, "No hay productos registrados"));
        }

        [HttpPost("Agregar_Producto")]
        public async Task<ActionResult<Producto>> AgragarProducto(Producto newProducto)
        {
            newProducto.FechaCreacion = DateTime.Now;
            _context.Productos.Add(newProducto);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, newProducto);
        }

        [HttpPut("Actualizar_Producto/{id}")]
        public async Task<ActionResult<Producto>> ActualizarProducto(int id, Producto newProducto)
        {
            var oldProducto = await _context.Productos.FindAsync(id);
            if (oldProducto != null)
            {
                oldProducto.Nombre = newProducto.Nombre;
                oldProducto.Descripcion = newProducto.Descripcion;
                oldProducto.Precio = newProducto.Precio;
                oldProducto.Categoria = newProducto.Categoria;
                oldProducto.FechaCreacion = DateTime.Now;
                await _context.SaveChangesAsync();
                return Ok(StatusCode(StatusCodes.Status200OK, newProducto));
            }
            return NotFound(StatusCode(StatusCodes.Status404NotFound, $"El producto con id: {id}, no existe"));
        }

        [HttpDelete("Eliminar_Producto/{id}")]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return Ok(StatusCode(StatusCodes.Status200OK, $"El producto {producto.Nombre} fue eliminado con exito"));
            }
            return NotFound(StatusCode(StatusCodes.Status404NotFound, "El usuario que trata de eliminar no existe"));
        }

        [HttpGet("Obtener_Producto/{id}")]
        public async Task<ActionResult> ObtenerProductoPorId(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                return Ok(StatusCode(StatusCodes.Status200OK, producto));
            }
            return NotFound(StatusCode(StatusCodes.Status404NotFound, "Este producto no existe"));
        }
    }
}