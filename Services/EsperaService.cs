using Desafio_API.DTO;
using Desafio_API.Model;
using Desafio_API.Repository;

namespace Desafio_API.Services
{

    public class EsperaService : IEsperaService
    {
        private readonly IEsperaRepository _repository;

        public EsperaService(IEsperaRepository repository )
        {
            _repository = repository;
        }

        public async Task<Espera> AdicionarEspera(EsperaDTO esperaDTO)
        {
            return await _repository.AdicionarEspera(Builder(esperaDTO));
        }

        public Espera Builder(EsperaDTO esperaDTO)
        {
            Espera espera = new Espera();
            espera.TipoAtendimento = esperaDTO.TipoAtendimento;
            espera.StatusPainel = false;
            espera.DtEmissao = DateTime.UtcNow;
            return espera;
        }
    }
}
