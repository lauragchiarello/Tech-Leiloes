using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

public class Favorito
{
    [Key]

    public int Id { get; set; }

    public DateTime CriadoEm { get; set; } = DateTime.Now; // DEFAULT GETDATE()

    // Propriedades de Navegação
    public string UsuarioId { get; set; }
    [ForeignKey(nameof(UsuarioId))]
    public Usuario Usuario { get; set; }

    public int ImovelId { get; set; }
    [ForeignKey(nameof(ImovelId))]
    public Imovel Imovel { get; set; }
}
