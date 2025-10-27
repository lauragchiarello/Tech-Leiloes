using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

public class Foto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    // Chave Estrangeira
    public int ImovelId { get; set; }

    [Required]
    [StringLength(500)]
    public string CaminhoImagem { get; set; }

    // Propriedade de Navegação
    [ForeignKey(nameof(ImovelId))]
    public Imovel Imovel { get; set; }
}
