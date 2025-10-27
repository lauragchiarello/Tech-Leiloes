using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

    public class SincronizacaoSiteLeiloeiro
    {
        [Key]
        public int SincronizacaoId { get; set; }
        
        public int LeiloeiroId { get; set; }
        [ForeignKey("LeiloeiroId")]
        public Leiloeiro Leiloeiro { get; set; }

        public int TotalLeiloes { get; set; }
        public int NovosLeiloes { get; set; }
        public int LeiloesRemovidos { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool Sucesso { get; set; }


    }
