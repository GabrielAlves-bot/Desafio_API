using Desafio_API.DTO;
using Desafio_API.Model;
using Desafio_API.Repository;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Desafio_API.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _aRepository;
        private readonly IEsperaRepository _eRepository;
        private static int contador = 1;

        public AtendimentoService(IAtendimentoRepository aRepository, IEsperaRepository eRepository)
        {
            _aRepository = aRepository;
            _eRepository = eRepository;
        }
        public async Task<Atendimento> IniciarAtendimento(AtendimentoDTO atendimentoDTO)
        {
            var novoAtendimento = await Builder(atendimentoDTO);
            var atendimento = await _aRepository.CriarAtendimento(novoAtendimento);
            return atendimento;
        }

        public async Task<List<AtendimentoComTempoDTO>> buscarAtendimentosComTempo()
        {
            List<AtendimentoComTempoDTO> atendimentosComTempo = new List<AtendimentoComTempoDTO>();
            List<Atendimento> atendimentos = await _aRepository.BuscarAtendimentos();

            atendimentos.ForEach(atendimento =>
            {
                atendimentosComTempo.Add(Builder(atendimento));
            });

            return atendimentosComTempo;
        }

        public async Task<Atendimento> Builder(AtendimentoDTO atendimentoDTO)
        {
            Atendimento atendimento = new Atendimento();
            Espera espera = null;

            if (contador > 3)
            {
                espera = await _eRepository.BuscarProximoPrioritario();
                contador = 1; 
            }
            else
            {
                espera = await _eRepository.BuscarProximoNormal();
                contador += 1;
            }

            if(espera == null)
            {
                espera = await _eRepository.BuscarProximoGenerico();

            }

            if(espera != null)
            {
                atendimento.DtAtendimento = DateTime.UtcNow;
                atendimento.Mesa = atendimentoDTO.Mesa;
                atendimento.Espera = espera;

                espera.StatusPainel = true;
                _eRepository.MudarStatusPainel(espera);

                return atendimento;
            }
            return null;
        }

        public AtendimentoComTempoDTO Builder(Atendimento atendimento)
        {
            TimeSpan tempoGasto = atendimento.DtAtendimento - atendimento.Espera.DtEmissao;
            AtendimentoComTempoDTO atendimentoComTempo = new AtendimentoComTempoDTO();

            atendimentoComTempo.ID = atendimento.ID;
            atendimentoComTempo.Mesa = atendimento.Mesa;
            atendimentoComTempo.EsperaId = atendimento.EsperaId;
            atendimentoComTempo.Espera = atendimento.Espera;
            atendimentoComTempo.DtAtendimento = atendimento.DtAtendimento;
            atendimentoComTempo.tempoGasto = ((int)tempoGasto.TotalMinutes) + " minutos.";

            return atendimentoComTempo;
        }
    }
}
