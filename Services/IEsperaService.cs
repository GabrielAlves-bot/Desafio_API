using Desafio_API.DTO;
using Desafio_API.Model;

namespace Desafio_API.Services
{
    public interface IEsperaService
    {
        public Task<Espera> AdicionarEspera(EsperaDTO esperaDTO);

        public Espera Builder(EsperaDTO esperaDTO);

    }
}
