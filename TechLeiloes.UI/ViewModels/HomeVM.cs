
using TechLeiloes.UI.DTOs;

namespace TechLeiloes.UI.ViewModels;

public class HomeVM
{
    public List<CategoriaDto> Categorias { get; set; } = new();
    public List<ProdutoDto> ProdutosDestaque { get; set; } = new();
}
