using Desafio_API.Model;

namespace Desafio_API.DTO
{
    public class AtendimentoComTempoDTO : Atendimento
    {
        public string tempoGasto { get; set; } = string.Empty;
    }
}
