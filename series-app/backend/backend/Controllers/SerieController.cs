using backend.Models;
using backend.Services;
using backend.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/v1/series")]
    public class SerieController : ControllerBase
    {
        private readonly SerieService _serieService;

        public SerieController(SerieService serieService)
        {
            _serieService = serieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Serie>>> Get()
        {
            List<Serie> series = await _serieService.findAllAsync();

            return Ok(series);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Serie>> Post([FromBody]Serie model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _serieService.createAsync(model);

                return Ok(model);
            }
            catch(Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar uma série" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Serie>> Put(
            int id,
            [FromBody]Serie model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != model.Id)
            {
                return NotFound(new { message = "Série não encontrada" });
            }

            try
            {
                await _serieService.UpdateAsync(model);
                return Ok(model);
            }
            catch(ApplicationException e)
            {
                return BadRequest(new { message = "Error: " + e.Message });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Serie>> Delete(int id)
        {
            try
            {
                await _serieService.RemoveAsync(id);
                return Ok(new { message = "Série removida com sucesso" });
            }
            catch(IntegrityException e)
            {
                return BadRequest(new { message = "Error: " + e.Message });
            }
        }
    }
}
