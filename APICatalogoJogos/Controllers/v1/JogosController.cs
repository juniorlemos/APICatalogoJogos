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
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }

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
       
        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> Post([FromBody]JogoInputModel jogoInputModel)
        {

            var jogo = await _jogoService.Post(jogoInputModel);
            return Ok(jogo);


        }
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> Put([FromRoute] Guid idJogo, [FromBody]JogoInputModel jogoImputModel)
        {
            await _jogoService.Put(idJogo, jogoImputModel);
            return Ok();
    }


    [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> Patch([FromRoute]Guid idJogo, [FromBody]double preco)
        {
            await _jogoService.Patch(idJogo, preco);
            return Ok();

        }
    
[HttpDelete]
    public async Task<ActionResult> Delete([FromRoute]Guid idJogo)
        {
            await _jogoService.Delete(idJogo);
            return Ok();
        }

    }
}
