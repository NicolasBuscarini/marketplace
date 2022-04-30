export class Produto {
  id: string;
  nome: string;
  descricao: string;
  preco: number;
  estoque: number;
  lojaId: string;
  loja: Loja;

  constructor(
    id: string,
    nome: string,
    descricao: string,
    preco: number,
    estoque: number,
    lojaId: string,
    loja: Loja
  ) {
    this.id = id;
    this.nome = nome;
    this.descricao = descricao;
    this.preco = preco;
    this.estoque = estoque;
    this.lojaId = lojaId;
    this.loja = loja;
  }
}
