using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get()
        {
            List<Product> products = await _productService.FindAllAsync();

            if(!products.Any())
            {
                return Ok(new { message = "Lista de produtos vazia" });
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await _productService.FindByIdAsync(id);

            if (product == null)
            {
                return NotFound(new { message = "Produto não encontrado" });
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        public async Task<ActionResult<List<Product>>> GetByCategory(int id)
        {
            List<Product> products = await _productService.FindByCategoryAsync(id);

            if (!products.Any())
            {
                return NotFound(new { message = "Produto(s) não encontrado(s)" });
            }

            return Ok(products);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Post([FromBody]Product model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _productService.CreateAsync(model);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar o produto" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> Put(
            int id,
            [FromBody]Product model)
        {
            if(id != model.Id)
            {
                return NotFound(new { message = "Produto não encontrado" });
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _productService.UpdateAsync(model);

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
                await _productService.RemoveAsync(id);
                return Ok(new { message = "Produto removido com sucesso" });
            }
            catch (ApplicationException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
