using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;
    public class Favoritos
    {   
        [Key]
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public int LeilaoId { get; set; }
        [ForeignKey("LeilaoId")]
        public Leilao Leilao { get; set; }
    }
