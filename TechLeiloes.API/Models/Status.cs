using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechLeiloes.API.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        
        public TipoStatus TipoStatus { get; set; }

        // Propriedades de Navegação (Relação 1:N com Imovel e HistoricoLeilao)
        public ICollection<Imovel> Imoveis { get; set; }
        public ICollection<HistoricoLeilao> Historicos { get; set; }
    }

    public enum TipoStatus
    {
        Ativo = 1,
        Suspenso = 2,
        Cancelado = 3,
        Vendido = 4

    }
}