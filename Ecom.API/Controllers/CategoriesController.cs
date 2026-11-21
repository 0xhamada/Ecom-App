using AutoMapper;
using Ecom.Core.DTO;
using Ecom.Core.Entities.Product;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work , IMapper mapper) : base(work , mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var category = await _work.CategoryRepositry.GetAllAsync();
                if(category == null || !category.Any())
                {
                    return NotFound("No categories found.");
                }
                return Ok(category);
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
                var category = await _work.CategoryRepositry.GetById(id);
                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDto)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryDto);

                await _work.CategoryRepositry.AddAsync(category);

                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDto)
        {
            try
            {
                var exist = await _work.CategoryRepositry.GetById(updateCategoryDto.Id);
                if (exist == null)
                {
                    return NotFound($"Category with ID {updateCategoryDto.Id} not found.");
                }

                var category = _mapper.Map<Category>(updateCategoryDto);
                await _work.CategoryRepositry.UpdateAsync(category);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _work.CategoryRepositry.GetById(id);
                if (category == null)
                {
                    return NotFound($"Category with ID {id} not found.");
                }

                await _work.CategoryRepositry.DeleteAsync(category.Id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
