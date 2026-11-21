using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{

    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _work.ProductRepositry.GetAllAsync(x=> x.Categories , x=> x.Photos);
                if (products == null || !products.Any())
                {
                    return NotFound("No products found.");
                }
                var result = _mapper.Map<List<ProductDTO>>(products);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _work.ProductRepositry.GetById(id, x => x.Categories, x => x.Photos);
                if (product == null)
                {
                    return NotFound("Product not found.");
                }
                var result = _mapper.Map<ProductDTO>(product);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(AddProductDTO productDto)
        {
            try
            {
                await _work.ProductRepositry.AddAsync(productDto);
                return Ok("Product added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateProductDTO productDto)
        {
            try
            {
                await _work.ProductRepositry.UpdateAsync(productDto);
                return Ok("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
