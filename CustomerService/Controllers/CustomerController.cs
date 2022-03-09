using CustomerService.IServices;
using CustomerService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService) 
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomers();
                if (customers == null)
                {
                    return NotFound();
                }

                return Ok(customers);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer(string? custId)
        {
            if (custId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await _customerService.GetCustomer(custId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cust = await _customerService.AddCustomer(customer);
                    if (cust > 0)
                    {
                        return StatusCode(200, cust);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(string? custId)
        {
            int result = 0;

            if (custId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _customerService.DeleteCustomer(custId);
                if (result > 0)
                {
                    return StatusCode(200, result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _customerService.UpdateCustomer(customer);

                    return StatusCode(200,result);
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

        //[HttpGet]
        //public string GetValues() 
        //{
        //    return "value"+"Customer test controller";
        //}
    }
}
