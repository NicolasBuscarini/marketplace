import { Loja } from "./loja";

export class Produto {
  id: string;
  nome: string;
  descricao: string;
  estoque: number;
  preco: number;
  imagemUrl: string;
  lojaId: string;
  loja?: Loja;

  constructor(
    id: string,
    nome: string,
    descricao: string,
    estoque: number,
    preco: number,
    imagemUrl: string,
    lojaId: string,
  ) {
    this.id = id;
    this.nome = nome;
    this.descricao = descricao;
    this.preco = preco;
    this.estoque = estoque;
    this.imagemUrl = imagemUrl;
    this.lojaId = lojaId;
  }
}
