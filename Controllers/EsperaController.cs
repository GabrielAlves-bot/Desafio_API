using Desafio_API.DTO;
using Desafio_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EsperaController : ControllerBase
    {
        private readonly IEsperaService _service;

        public EsperaController(IEsperaService service)
        {
            _service = service;
        }

        [HttpPost]

        public async Task<ActionResult> Post(EsperaDTO esperaDTO)
        {
            if(esperaDTO.TipoAtendimento > 2 || esperaDTO.TipoAtendimento == 0)
            {
                return BadRequest("Ensira um valor válido!");  
            }
            var esperaAtual = await _service.AdicionarEspera(esperaDTO);
                return Ok(esperaAtual);
        }
    }
}
