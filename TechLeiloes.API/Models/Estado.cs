using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechLeiloes.API.Models;

public class Estado
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(2)]
    public string SiglaEstado { get; set; }

    [Required]
    [StringLength(50)]
    public string NomeEstado { get; set; }

    // Propriedade de Navegação (Relação 1:N com Imovel)
    public ICollection<Imovel> Imoveis { get; set; }
}
