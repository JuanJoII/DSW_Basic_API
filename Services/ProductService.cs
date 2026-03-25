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
    public class ProductService : IProductService
    {
        private readonly DbGeneralContext _context;
        public ProductService(DbGeneralContext context)
        {
            _context = context;
        }
        public async Task<Producto> CreateProductAsync(CreateProductDTO product)
        {
            var nuevoProducto = new Producto
            {
                Nombre = product.Nombre,
                Descripcion = product.Descripcion,
                Precio = product.Precio,
                Stock = product.Stock,
                Categoria = product.Categoria,
                FechaCreacion = DateTime.UtcNow,
            };
            _context.Productos.Add(nuevoProducto);
            await _context.SaveChangesAsync();
            return nuevoProducto;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Productos.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Productos.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Producto>> GetAllProductsAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto> GetProductByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> UpdateProductAsync(int id, Producto newProduct)
        {
            var existingProduct = await _context.Productos.FindAsync(id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.Nombre = newProduct.Nombre;
            existingProduct.Descripcion = newProduct.Descripcion;
            existingProduct.Precio = newProduct.Precio;
            existingProduct.Categoria = newProduct.Categoria;
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}