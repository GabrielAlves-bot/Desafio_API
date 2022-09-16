using Desafio_API.DTO;
using Desafio_API.Model;

namespace Desafio_API.Repository
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> CriarAtendimento(Atendimento atendimento);
        Task<List<Atendimento>> BuscarAtendimentos();
    }
}
