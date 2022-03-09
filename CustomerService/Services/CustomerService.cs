using CustomerService.IServices;
using CustomerService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Services
{
    public class CustomersService : ICustomerService
    {
       private readonly TestDBContext db;
        public CustomersService(TestDBContext _db)  
        {
            db = _db;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            int result = 0;

            if (db != null)
            {
                await db.Customers.AddAsync(customer);
                result= await db.SaveChangesAsync();
            }

            return result;
        }

        public async Task<int> DeleteCustomer(string? custId)
        {
            int result = 0;

            if (db != null)
            {
                //Find the post for specific post id
                var post = await db.Customers.FirstOrDefaultAsync(x => x.Id == custId);

                if (post != null)
                {
                    db.Customers.Remove(post);

                    //Commit the transaction
                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<Customer> GetCustomer(string? custId)
        {
            if (db != null)
            {
                return await db.Customers.Where(x=>x.Id==custId).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            if (db != null)
            {
                return await db.Customers.ToListAsync();
            }

            return null;
        }

        public async Task<int> UpdateCustomer(Customer customer)
        {
            int result = 0;
            if (db != null)
            {
                var cust = db.Customers.Where(x => x.Id.Equals(customer.Id)).FirstOrDefault();
                cust.Name = customer.Name;
                db.Customers.Update(cust);
                //Commit the transaction
              result=  await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
