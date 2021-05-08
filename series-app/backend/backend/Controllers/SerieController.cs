using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
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

        // Post

        // Put

        // Delete
    }
}
