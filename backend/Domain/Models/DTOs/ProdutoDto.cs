namespace MarketPlace.Domain.Models.DTOs;

public class ProdutoDto
{
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public string ImagemUrl { get; set; } = null!;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public Guid LojaId { get; set; }
}