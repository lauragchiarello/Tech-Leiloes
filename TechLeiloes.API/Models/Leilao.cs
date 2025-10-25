using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechLeiloes.API.Models;
    public class Leilao
    {   [Key]
        public int Id { get; set; }

        public int LeiloeiroId { get; set; }
        [ForeignKey("LeiloeiroId")]
        public Leiloeiro Leiloeiro { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        public int EstadoId { get; set; }
        [ForeignKey("EstadoId")]
        public Estado Estado { get; set; }

        public int FotoId { get; set; }
        [ForeignKey("FotoId")]
        public Foto Foto{ get; set; }

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string Edital { get; set; }

        public string Descricao { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime PrimeiraPraca { get; set; }

        public float ValorPP { get; set; }

        [DataType(DataType.Date)]
        public DateTime SegundaPraca { get; set; }

        public float ValorSP { get; set; }

        public int Desconto { get; set; }

        [DataType(DataType.Date)]
        public DateTime CriadoEm { get; set; }

        public string WebsiteLeiloeiro { get; set; }
    }
