using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechLeiloes.API.Models;
    public class Estado
    {   
        [Key]
        public int Id { get; set; }
        public string SiglaEstado { get; set; }
    }
