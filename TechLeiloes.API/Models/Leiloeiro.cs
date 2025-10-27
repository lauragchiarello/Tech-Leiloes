using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechLeiloes.API.Models;

public class Leiloeiro
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(12)]
    public string Telefone { get; set; }

    [Required]
    [StringLength(300)]
    public string WebSite { get; set; }

    // Propriedade de Navegação (Relação 1:N com Imovel e SincronizacaoSiteLeiloeiro)
    public ICollection<Imovel> Imoveis { get; set; }
    public ICollection<SincronizacaoSiteLeiloeiro> Sincronizacoes { get; set; }

}
