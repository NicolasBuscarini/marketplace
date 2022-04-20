using MarketPlace.Domain.Models.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MarketPlace.Domain.Models
{
    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [JsonIgnore]
        public List<Produto>? Produtos { get; set; }

        public Loja()
        {
        }

        public Loja(string nome, string descricao, decimal cnpj, List<Produto>? produtos)
        {
            Nome = nome;
            Descricao = descricao;
            Produtos = produtos;
        }

        public Loja(LojaDto lojaDto, Guid userId)
        {
            Nome = lojaDto.Nome;
            Descricao = lojaDto.Descricao;
            UserId = userId;
        }
    }
}
