using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.IServices
{
  public  interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProduct(string? prodId); 

        Task<int> AddProduct(Product product);

        Task<int> DeleteProduct(string? prodId);

        Task<int> UpdateProduct(Product product);
    }
}
