using APICatalogoJogos.InputModel;
using APICatalogoJogos.Services;
using APICatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoJogos.Controllers.v1
{
    [Route("api/v1/[controller]")]
   
    [ApiController]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

        /// <summary>
        /// Lista os filmes de forma paginada
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Get( [FromQuery ,Range(1,int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade =5 )
        {
            var jogos = await _jogoService.Get(pagina, quantidade);

            if (jogos.Count()==0 ) 
            {
                return NoContent(); 
            }
            return Ok(jogos);
        }
        /// <summary>
        /// Lista um filme pelo ID.
        /// </summary>
       
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> GetId([FromRoute]Guid idJogo)
        {
            var jogo = await _jogoService.GetId(idJogo);
            if (jogo == null)
            {
                return NoContent();
            }

            return Ok(jogo);
        }
        /// <summary>
        /// Insere um filme.
        /// </summary>

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Post([FromBody]JogoInputModel jogoInputModel)
        {

            var jogo = await _jogoService.Post(jogoInputModel);
            return Ok(jogo);


        }
        /// <summary>
        /// Altera  um filme usando o ID.
        /// </summary>
          

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> Put([FromRoute] Guid idJogo, [FromBody]JogoInputModel jogoImputModel)
        {
            await _jogoService.Put(idJogo, jogoImputModel);
            return Ok();
    }


        /// <summary>
        /// Deleta um filme.
        /// </summary>

        [HttpDelete]
       
        public async Task<ActionResult> Delete([FromRoute]Guid idJogo)
        {
            await _jogoService.Delete(idJogo);
            return Ok();
        }

    }
}
