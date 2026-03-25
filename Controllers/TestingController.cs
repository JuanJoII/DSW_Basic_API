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
    public class TestingController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public TestingController(IProductService productService)
        {
            _ProductService = productService;
        }

        [HttpGet("Test_Filter")]
        [ServiceFilter(typeof(TestFilter))]
        public IActionResult TestFilter()
        {
            return Ok("Test Filter Executed");
        }

        [HttpGet("All_Products_Service")]
        public async Task<ActionResult<IEnumerable<Producto>>> ObtenerProductos()
        {
            var productos = await _ProductService.GetAllProductsAsync();
            if (productos != null)
            {
                return Ok(StatusCode(StatusCodes.Status200OK, productos));
            }
            return StatusCode(StatusCodes.Status404NotFound, "No hay productos registrados");
        }

        [HttpPost("Create_Product_Service")]
        public async Task<ActionResult<Producto>> CrearProducto(CreateProductDTO dTO)
        {
            try
            {
                if (dTO == null)
                {
                    return BadRequest("El producto no puede ser nulo");
                }
                if (string.IsNullOrEmpty(dTO.Nombre) || string.IsNullOrEmpty(dTO.Categoria))
                {
                    return BadRequest("El nombre y la categoría son campos obligatorios");
                }
                if (dTO.Precio <= 0 || dTO.Stock <= 0)
                {
                    return BadRequest("El precio y el stock no pueden ser negativos ni iguales a 0");
                }
                var productoCreado = await _ProductService.CreateProductAsync(dTO);
                return StatusCode(StatusCodes.Status201Created, productoCreado);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el producto: {ex.Message}");
            }
        }
    }
}