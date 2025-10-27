using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechLeiloes.API.Models;

public class Imovel
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string Endereco { get; set; }

    [StringLength(100)]
    public string Cidade { get; set; }

    [StringLength(10)]
    public string Cep { get; set; }

    [StringLength(255)]
    public string Edital { get; set; }

    [StringLength(1000)]
    public string Descricao { get; set; }

    [DataType(DataType.Date)]
    public DateTime PrimeiraPraca { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ValorPP { get; set; }


    [DataType(DataType.Date)]
    public DateTime SegundaPraca { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ValorSP { get; set; }

    public int Desconto { get; set; }

    [DataType(DataType.Date)]
    public DateTime CriadoEm { get; set; } = DateTime.Now; // DEFAULT GETDATE()

    [StringLength(200)]
    public string WebsiteLeiloeiro { get; set; }

    public int LeiloeiroId { get; set; }
    [ForeignKey("LeiloeiroId")]
    public Leiloeiro Leiloeiro { get; set; }

    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; }

    public int EstadoId { get; set; }
    [ForeignKey("EstadoId")]
    public Estado Estado { get; set; }


    public int StatusId { get; set; }
    [ForeignKey("StatusId")]
    public Status Status { get; set; }


    public ICollection<Foto> Fotos { get; set; }
    public ICollection<Favorito> Favoritos { get; set; }
    public ICollection<HistoricoLeilao> Historicos { get; set; }
}
