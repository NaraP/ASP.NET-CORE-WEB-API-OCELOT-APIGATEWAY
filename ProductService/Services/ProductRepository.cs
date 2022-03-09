using Microsoft.EntityFrameworkCore;
using ProductService.IServices;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Services
{
    public class ProductRepository : IProductRepository
    {
        TestDBContext db;
        public ProductRepository(TestDBContext _db)
        {
            db = _db;
        }

        public async Task<int> AddProduct(Product product)
        {
            int result = 0;

            if (db != null)
            {
                await db.Products.AddAsync(product);
                result= await db.SaveChangesAsync();
            }

            return result;
        }

        public async Task<int> DeleteProduct(string? prodId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var product = await db.Products.FirstOrDefaultAsync(x => x.Id == prodId); 

                if (product != null)
                {
                    db.Products.Remove(product);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<Product> GetProduct(string? custId)
        {
            if (db != null)
            {
                return await db.Products.Where(x => x.Id == custId).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<Product>> GetProducts()
        {
            if (db != null)
            {
                return await db.Products.ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            int result = 0;

            if (db != null)
            {
                var prod = db.Products.Where(x => x.Id.Equals(product.Id)).FirstOrDefault();

                prod.Name = product.Name;
                db.Products.Update(prod);

                //Commit the transaction
               result= await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
