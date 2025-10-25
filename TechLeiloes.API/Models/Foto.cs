using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models;

    public class Foto
    {
        [Key]
        public int Id { get; set; }
        public string Imagem { get; set; }
    }
