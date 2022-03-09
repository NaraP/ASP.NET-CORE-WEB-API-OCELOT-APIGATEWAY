using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.IServices;
using ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() 
        {
            try
            {
                var products = await _productRepository.GetProducts();
                if (products == null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(string? productId)
        {
            if (productId == null)
            {
                return BadRequest();
            }

            try
            {
                var product = await _productRepository.GetProduct(productId);

                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var prod = await _productRepository.AddProduct(product);
                    if (prod > 0)
                    {
                        return StatusCode(200, prod);
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
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(string? prodId)
        {
            int result = 0;

            if (prodId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await _productRepository.DeleteProduct(prodId);
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
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _productRepository.UpdateProduct(product);

                    return StatusCode(200, result);
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
    }
}
