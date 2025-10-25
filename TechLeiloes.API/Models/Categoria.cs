using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TechLeiloes.API.Models;
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Tipo  { get; set; }
    }
