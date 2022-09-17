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


        /// <summary>
        /// Criar Um Novo Atendimento.
        /// </summary>
        /// <returns>Um Novo Atendimento</returns>
        /// <response code="200">Returna a criação de um atendimento.</response>
        [HttpPost]
        public async Task<ActionResult> CriarAtendimento(AtendimentoDTO atendimentoDTO)
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

        /// <summary>
        /// Gerar Relatório De Atendimentos.
        /// </summary>
        /// <returns>Um Relatório</returns>
        /// <response code="200">Returna uma relatório </response>
        [HttpGet]
        public async Task<ActionResult> GerarRelatorioDeAtendimentos()
        {
            try
            { 
           var atendimentos = await _service.buscarAtendimentosComTempo();
           return Ok(atendimentos);
            }
            catch
            {
                return BadRequest("Não foi possível listar os atendimentos");
            }
        }
    }
}
