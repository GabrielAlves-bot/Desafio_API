using Desafio_API.DTO;
using Desafio_API.Model;
using Desafio_API.Repository;
using Desafio_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio_API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AtendimentoController : ControllerBase
    {
        private readonly IAtendimentoService _service;

        public AtendimentoController(IAtendimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> GerarAtendimento(AtendimentoDTO atendimentoDTO)
        {
            try
            {
                var atendimento = await _service.IniciarAtendimento(atendimentoDTO);
                return Ok(atendimento);
            }
            catch
            {
                return BadRequest("Não foi possível iniciar o atendimento.");
            }
        }

        [HttpGet]
        public async Task<ActionResult> buscarAtendimentosComTempo()
        {
           var atendimentos = await _service.buscarAtendimentosComTempo();
           return Ok(atendimentos);
        }
    }
}
