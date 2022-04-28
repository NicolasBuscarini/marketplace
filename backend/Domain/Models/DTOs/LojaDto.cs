namespace MarketPlace.Domain.Models.DTOs;

public class LojaDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
}