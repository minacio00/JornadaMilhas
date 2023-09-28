using System.ComponentModel.DataAnnotations;


namespace JornadaMilhas.Models;

public class Depoimento
{
    [Required]
    [Key]
    public int Id {get; set;}

    [Required(ErrorMessage ="Missing picture Url")]
    public string Foto {get; set;}

    [Required(ErrorMessage ="Mising message")]
    public string Mensagem {get; set;}

    [Required(ErrorMessage ="Mising name")]
    public string Nome {get; set;}


}