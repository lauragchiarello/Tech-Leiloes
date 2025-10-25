using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;
public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "O e-mail é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O telefone é obrigatório")]
    public string Telefone { get; set; }

    [DataType(DataType.Date)]
    public DateTime Data_Nascimento { get; set; }
    [Required(ErrorMessage = "A profissão é obrigatória")]
    public string Profissao { get; set; }

    [DataType(DataType.Date)]
    public DateTime CriacaoConta { get; set; }

    public NivelExperiencia Nivel { get; set; }

}
public enum NivelExperiencia
{
    Iniciante = 1,
    Investidor = 2,
    Profissional = 3
}
