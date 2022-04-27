using MarketPlace.Domain.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using MarketPlace.Interfaces.IGeneric;

namespace MarketPlace.Domain.Models;

public class Produto : IResultSearch
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Guid LojaId { get; private set; }
    [ForeignKey("LojaId")] public Loja? Loja => null;

    public Produto(string nome, string descricao, decimal preco, int estoque, Guid lojaId)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
        Preco = preco;
        Estoque = estoque;
        LojaId = lojaId;
    }

    public Produto(ProdutoDto produtoDto)
    {
        Nome = produtoDto.Nome;
        Descricao = produtoDto.Descricao;
        Preco = produtoDto.Preco;
        Estoque = produtoDto.Estoque;
        LojaId = produtoDto.LojaId;
    }
}