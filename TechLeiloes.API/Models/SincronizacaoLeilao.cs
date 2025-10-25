using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

    public class SincronizacaoLeilao
    {
        [Key]
        public int Id { get; set; }
        
        public int LeiloeiroId { get; set; }
        [ForeignKey("LeiloeiroId")]
        public Leiloeiro Leiloeiro { get; set; }

        public int TotalLeiloes { get; set; }
        public int NovosLeiloes { get; set; }
        public int LeiloesRemovidos { get; set; }

        [DataType(DataType.Date)]
        public DateTime Inicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fim { get; set; }
        public bool Sucesso { get; set; }


    }
