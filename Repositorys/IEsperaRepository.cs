using Desafio_API.Model;

namespace Desafio_API.Repository
{
    public interface IEsperaRepository
    {
        public Task<Espera> AdicionarEspera(Espera espera);
        public Task<Espera?> BuscarProximoNormal();
        public Task<Espera?> BuscarProximoPrioritario();
        public void MudarStatusPainel(Espera espera);
        public Task<Espera?> BuscarProximoGenerico();
    }
}
