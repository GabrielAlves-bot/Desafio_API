using Desafio_API.Data;
using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API.Repository
{
    public class EsperaRepository : IEsperaRepository
    {
        private readonly ApiContext _context;

        public EsperaRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task<Espera> AdicionarEspera(Espera espera)
        {
           _context.Espera.Add(espera);
            await _context.SaveChangesAsync();
            return espera;
        }

        public async Task<Espera?> BuscarProximoNormal()
        {
           return await _context.Espera.Where(x => x.StatusPainel == false && x.TipoAtendimento == 1).OrderBy(x => x.DtEmissao).FirstOrDefaultAsync();
        }

        public async Task<Espera?> BuscarProximoPrioritario()
        {
            return await _context.Espera.Where(x => x.StatusPainel == false && x.TipoAtendimento == 2).OrderBy(x => x.DtEmissao).FirstOrDefaultAsync();
        }

        public async void MudarStatusPainel(Espera espera)
        {
            _context.Update(espera);
            await _context.SaveChangesAsync();
        }
    }
}
