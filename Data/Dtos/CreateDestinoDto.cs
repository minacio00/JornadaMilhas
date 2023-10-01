using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.Data.Dtos
{
    public class CreateDestinoDto
    {
        [Url]
        public string Foto1 { get; set; }
        [Url]
        public string Foto2 { get; set; }

        [Required(ErrorMessage = "Nome do destino e obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo meta é obrigatório")]
        [MaxLength(160)]
        public string Meta { get; set; }

        public string TextoDescritivo { get; set; }

        [Required(ErrorMessage = "Preco e obrigatorio")]
        public string Preco { get; set; }
    }
}