using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models
{
    public class Status
    {   
        [Key]
        public int Id { get; set; }
        public TipoStatus TipoStatus { get; set; }
    }

    public enum TipoStatus
    {
        Ativo = 1,
        Suspenso = 2,
        Cancelado = 3,
        Vendido = 4
  
    }
}