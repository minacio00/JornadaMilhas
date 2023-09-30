using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.Data.Dtos
{
    public class CreateDestinoDto
    {
        [Url]
        public string Foto { get; set; }

        [Required(ErrorMessage = "Nome do destino é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preço é obrigatório")]
        public string Preco { get; set; }
    }
}