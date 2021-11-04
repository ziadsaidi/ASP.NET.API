using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;
using Supermarket.API.Extensions;
using Supermarket.API.Domain.Services.Communication;

namespace Supermarket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {

         private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;   
        }

         [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            
            return resources;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryResponse resource)
         {
             if (!ModelState.IsValid)
		        return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<CategoryResponse, Category>(resource);

           var result = await _categoryService.SaveAsync(category);

           if (!result.Success)
		        return BadRequest(result.Message);

           var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	            return Ok(categoryResource);

         }

         [HttpPut("{id}")]
public async Task<IActionResult> PutAsync(int id, [FromBody] CategoryResponse resource)
{
	if (!ModelState.IsValid)
		return BadRequest(ModelState.GetErrorMessages());

	var category = _mapper.Map<CategoryResponse, Category>(resource);
	var result = await _categoryService.UpdateAsync(id, category);

	if (!result.Success)
		return BadRequest(result.Message);

	var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	return Ok(categoryResource);
}


[HttpDelete("{id}")]
public async Task<IActionResult> DeleteAsync(int id)
{
	var result = await _categoryService.DeleteAsync(id);

	if (!result.Success)
		return BadRequest(result.Message);

	var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
	return Ok(categoryResource);
}
        
    }
}