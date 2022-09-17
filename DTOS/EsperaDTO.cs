using System.ComponentModel.DataAnnotations;

namespace Desafio_API.DTO
{
    public class EsperaDTO
    {
        [Required]
        [Range(1, 2,ErrorMessage = "O Campo deve ser preenchido apenas com 1 - Normal ou 2 - Prioritario.")]
        public int TipoAtendimento { get; set; }
    }
}
