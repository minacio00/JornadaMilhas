using System.ComponentModel.DataAnnotations;

namespace JornadaMilhas.Data.Dtos;

public class UpdateDepoimentoDto
{
    [Required(ErrorMessage ="Missing picture Url")]
    public string Foto {get; set;}

    [Required(ErrorMessage ="Mising message")]
    public string Mensagem {get; set;}

    [Required(ErrorMessage ="Mising name")]
    public string Nome {get; set;}

}