using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("v1/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await _categoryService.FindAllAsync();

            if (!categories.Any())
            {
                return Ok(new { message = "Não existe nenhuma categoria" });
            }
            else
            {
                return Ok(categories);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            Category category = await _categoryService.FindByIdAsync(id);

            if (category == null)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Category>> Post([FromBody]Category model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _categoryService.CreateAsync(model);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar a categoria" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Category>> Put(
            int id, 
            [FromBody]Category model)
        {
            if(id != model.Id)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _categoryService.UpdateAsync(model);

                return Ok(model);
            }
            catch(ApplicationException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.RemoveAsync(id);
                return Ok(new { message = "Categoria removida com sucesso" });
            }
            catch(ApplicationException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}