using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogoJogos.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Jogos : ControllerBase
    {

        [HttpGet]
        public async Task <ActionResult<List<object>>> Get()
        {
            return Ok();
        }
        [HttpGet ("{idJogo:guid}")]
        public async Task<ActionResult<List<object>>> GetId(Guid idJogo)
        {
            return Ok();
        }
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult<List<object>>> Put(Guid idJogo ,Object jogo)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult<List<object>>> Post(Object jogo)
        {
            return Ok();
        }
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult<List<object>>> Patch(Guid idJogo , double preco)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult<List<object>>> Delete(Guid idJogo)
        {
            return Ok();
        }
      

      

    }
}
