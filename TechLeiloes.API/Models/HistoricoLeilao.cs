using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

    public class HistoricoLeilao
    {   [Key]
        public int Id { get; set; }
        public int LeilaoId { get; set; }
        [ForeignKey("LeilaoId")]
        public Leilao Leilao { get; set; }
        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

    }
