using catalogo_jogos_api.Exceptions;
using catalogo_jogos_api.InputModel;
using catalogo_jogos_api.Services.Interfaces;
using catalogo_jogos_api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace catalogo_jogos_api.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Get(
            [FromQuery, Range(1, int.MaxValue)]int pagina = 1,
            [FromQuery, Range(1, 50)]int quantidade = 5)
        {
            var jogos = await _jogoService.Get(pagina, quantidade);

            if (jogos.Count == 0)
                return NoContent();

            return Ok(jogos);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<List<JogoViewModel>>> GetById([FromRoute]Guid id)
        {
            var jogo = await _jogoService.GetById(id);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Post([FromBody]JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _jogoService.Post(jogoInputModel);

                return Ok(jogo);
            }
            catch(JogoJaCadastradoException)
            {
                return UnprocessableEntity("Já existe um jogo com esse nome para essa produtora");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put([FromRoute]Guid id, [FromBody]JogoInputModel jogoInputModel)
        {
            try
            {
                await _jogoService.Put(id, jogoInputModel);

                return Ok();
            }
            catch(JogoJaCadastradoException)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpPatch("{id:guid}/preco/{preco:double}")]
        public async Task<ActionResult> Patch([FromRoute]Guid id, [FromRoute]double preco)
        {
            try
            {
                await _jogoService.Patch(id, preco);

                return Ok();
            }
            catch(JogoJaCadastradoException)
            {
                return NotFound("Não existe esse jogo");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute]Guid id)
        {
            try
            {
                await _jogoService.Delete(id);

                return Ok();
            }
            catch(JogoJaCadastradoException)
            {
                return NotFound("Não existe esse jogo");
            }
        }
    }
}
