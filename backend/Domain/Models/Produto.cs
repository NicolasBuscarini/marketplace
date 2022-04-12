namespace MarketPlace.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

        public Produto( string nome, string descricao, decimal preco, int estoque )
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Preco = preco;
            Estoque = estoque;
        }
    }
}
