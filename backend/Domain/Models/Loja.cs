using MarketPlace.Domain.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarketPlace.Domain.Models;

public class Loja
{
    public int Id { get; private set; }
    public string Nome { get;  set; }
    public string Descricao { get;  set; }
    public decimal Cnpj { get; }
    public Guid UserId { get; private set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; private set; }

    [JsonIgnore]
    public List<Produto>? Produtos { get; private set; }

    public Loja()
    {
    }

    public Loja(string nome, string descricao, decimal cnpj, List<Produto>? produtos)
    {
        Nome = nome;
        Descricao = descricao;
        Cnpj = cnpj;
        Produtos = produtos;
    }

    public Loja(LojaDto lojaDto, Guid userId)
    {
        Nome = lojaDto.Nome;
        Descricao = lojaDto.Descricao;
        UserId = userId;
    }
}