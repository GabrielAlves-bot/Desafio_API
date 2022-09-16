using Desafio_API.DTO;
using Desafio_API.Model;

namespace Desafio_API.Services
{
    public interface IAtendimentoService
    {
        public Task<Atendimento> IniciarAtendimento(AtendimentoDTO atendimentoDTO);

        public Task<List<AtendimentoComTempoDTO>> buscarAtendimentosComTempo();

        public Task<Atendimento> Builder(AtendimentoDTO atendimentoDTO);
        public AtendimentoComTempoDTO Builder(Atendimento atendimento);
    }
}
