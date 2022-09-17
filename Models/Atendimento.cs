using System.Diagnostics;

namespace Desafio_API.Model
{
    public class Atendimento
    {
        public int ID { get; set; }
        public int Mesa { get; set; }
        public DateTime DtAtendimento  { get; set; } 
        public int EsperaId { get; set; }
        public virtual Espera Espera { get; set; }

    }
}
