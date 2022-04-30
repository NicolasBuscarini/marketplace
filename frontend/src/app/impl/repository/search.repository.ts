
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "../../../environments/environment";
import { SearchDto } from "../../domain/models/dto/searchDto";
import { Produto } from "../../domain/models/produto";

@Injectable({
providedIn: 'root'
})  
export class SearchRepository {  
    private apiUrl = environment.apiUrl;

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };

    constructor(
        private httpClient: HttpClient
    ) { }

    SearchProduto (searchDto: SearchDto): Observable<Produto[]> {
        return this.httpClient
          .post<Produto[]>(`${this.apiUrl}/api/Search/search-produto`, searchDto , this.httpOptions)
          .pipe(
            map((res: any) => {
              return res.map((item: Produto) => {
                return new Produto(
                  item.id,
                  item.nome,
                  item.descricao,
                  item.estoque,
                  item.preco,
                  item.lojaId,
                  item.loja
                );
              });
            })
          );
      }

}
