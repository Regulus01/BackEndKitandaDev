using System.Text.Json.Serialization;
using ProductAPI.Data.ViewModels;

namespace Domain.Data.ViewModels.Criacao;

public class ProdutoViewModel
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }

    public ImagemProdutoGridViewModel? Imagem { get; set; }
    
}