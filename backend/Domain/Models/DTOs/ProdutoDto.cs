namespace MarketPlace.Domain.Models.DTOs
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int LojaId { get; set; }
    }
}
