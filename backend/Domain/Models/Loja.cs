namespace MarketPlace.Domain.Models
{
    public class Loja
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Cnpj { get; private set; }
        public List<Produto> Produtos { get; set; }

    }
}
