using Desafio_API.Data;
using Desafio_API.DTO;
using Desafio_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Desafio_API.Repository
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly AtendimentoContext _context;

        public AtendimentoRepository(AtendimentoContext context)
        {
            _context = context;
        }
        public async Task<Atendimento> CriarAtendimento(Atendimento atendimento)
        {
            _context.Atendimento.Add(atendimento);
             await _context.SaveChangesAsync();
            return atendimento;
        }

        public async Task<List<Atendimento>> BuscarAtendimentos()
        {
            return await _context.Atendimento.Include(x => x.Espera).ToListAsync();
        }

    }
}
