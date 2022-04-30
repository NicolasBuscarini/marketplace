import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchDto } from '../../domain/models/dto/searchDto';
import { Produto } from '../../domain/models/produto';
import { SearchRepository } from '../repository/search.repository';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  
  private _searchRepository: SearchRepository;

  constructor(searchRepository: SearchRepository) {
    this._searchRepository = searchRepository;
  }

  searchProduto(searchDto: SearchDto): Observable<Produto[]> {
    return this._searchRepository.SearchProduto(searchDto).pipe((ret) => {
      return ret;
    });
  }

}