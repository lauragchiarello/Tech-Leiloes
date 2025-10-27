using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

public class HistoricoLeilao
{
    [Key]
    public int Id { get; set; }

    public int ImovelId { get; set; }
    [ForeignKey("ImovelId")]
    public Imovel Imovel { get; set; }

    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public Status Status { get; set; }

}
