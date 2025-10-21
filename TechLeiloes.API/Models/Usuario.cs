

namespace TechLeiloes.API.Models;
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Data_Nascimento { get; set; }
        public string Profissao { get; set; }
        public DateTime CriacaoConta { get; set; }
        public enum NivelExperiencia;
    }
 