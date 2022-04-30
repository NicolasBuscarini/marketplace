import { User } from "./user";

export class Loja {
  
    id: string;
    nome: string;
    descricao: string;
    cnpj: string;
    userId: string;
    user: User;
  
    constructor(
      id: string,
      nome: string,
      descricao: string,
      cnpj: string,
      userId: string,
      user: User
    ) {
      this.id = id;
      this.nome = nome;
      this.descricao = descricao;
      this.cnpj = cnpj;
      this.userId = userId;
      this.user = user;
    }
  }
  