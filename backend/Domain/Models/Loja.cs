using MarketPlace.Domain.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MarketPlace.Interfaces.IGeneric;

namespace MarketPlace.Domain.Models;

public class Loja : IResultSearch
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
    public decimal Cnpj { get; }
    public Guid UserId { get; }
    [ForeignKey("UserId")] public ApplicationUser User { get; private set; } = null!;

    [JsonIgnore] public List<Produto>? Produtos { get; }

    public Loja()
    {
    }

    public Loja(LojaDto lojaDto, Guid userId)
    {
        Nome = lojaDto.Nome;
        Descricao = lojaDto.Descricao;
        UserId = userId;
    }
}