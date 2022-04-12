using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

        [ForeignKey("LojaId")]
        public Loja Loja { get; private set; }

    }
}
