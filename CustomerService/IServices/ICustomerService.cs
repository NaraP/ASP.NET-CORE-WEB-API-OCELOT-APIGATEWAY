using CustomerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.IServices
{
   public interface ICustomerService 
    {
        Task<List<Customer>> GetCustomers(); 

        Task<Customer> GetCustomer(string? custId);

        Task<int> AddCustomer(Customer customer);

        Task<int> DeleteCustomer(string? custId); 

        Task<int> UpdateCustomer(Customer customer);
    }
}
