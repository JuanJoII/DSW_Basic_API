using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSW_Basic_API.DTOs;
using Web_API_Usuario.Models;

namespace DSW_Basic_API.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Producto>> GetAllProductsAsync();
        Task<Producto> GetProductByIdAsync(int id);
        Task<Producto> CreateProductAsync(CreateProductDTO product);
        Task<Producto> UpdateProductAsync(int id, Producto product);
        Task<bool> DeleteProductAsync(int id);
    }
}