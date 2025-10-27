using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechLeiloes.API.Models
{
    public class Usuario : IdentityUser
    {


        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "O telefone é obrigatório")]
        public string Telefone { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A profissão é obrigatória")]
        public string Profissao { get; set; }

        [DataType(DataType.Date)]
        public DateTime CriacaoConta { get; set; } = DateTime.Now;

        public NivelExperiencia Nivel { get; set; }
        public string Foto { get; set; }

        // Propriedade de Navegação (Relação N:N com Imovel)
        public ICollection<Favorito> Favoritos { get; set; }
    }

    public enum NivelExperiencia
    {
        Iniciante = 1,
        Intermediário = 2,
        Profissional = 3
    }
}