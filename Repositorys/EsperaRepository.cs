using Desafio_API.Data;
using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API.Repository
{
    public class EsperaRepository : IEsperaRepository
    {
        private readonly EsperaContext _context;

        public EsperaRepository(EsperaContext context)
        {
            _context = context;
        }
        public async Task<Espera> AdicionarEspera(Espera espera)
        {
           _context.Esperas.Add(espera);
            await _context.SaveChangesAsync();
            return espera;
        }

        public async Task<Espera?> BuscarProximoGenerico()
        {
            return await _context.Esperas.Where(x => x.StatusPainel == false).OrderBy(x => x.DtEmissao).FirstOrDefaultAsync();
        }

        public async Task<Espera?> BuscarProximoNormal()
        {
           return await _context.Esperas.Where(x => x.StatusPainel == false && x.TipoAtendimento == 1).OrderBy(x => x.DtEmissao).FirstOrDefaultAsync();
        }

        public async Task<Espera?> BuscarProximoPrioritario()
        {
            return await _context.Esperas.Where(x => x.StatusPainel == false && x.TipoAtendimento == 2).OrderBy(x => x.DtEmissao).FirstOrDefaultAsync();
        }

        public async void MudarStatusPainel(Espera espera)
        {
            _context.Update(espera);
            await _context.SaveChangesAsync();
        }
    }
}
