import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs/internal/Subscription';
import { SearchDto } from '../../../domain/models/dto/searchDto';
import { Produto } from '../../../domain/models/produto';
import { SearchService } from '../../../impl/services/search.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  private _searchService: SearchService;
  public currentPage: number;
  public pageSize;
  public result: Produto[] = [];

  public erro?: HttpErrorResponse = undefined;

  constructor(searchService: SearchService) {
    this._searchService = searchService;

    this.currentPage = 1;
    this.pageSize = 6;

    this.searchProduto(
      new SearchDto(this.currentPage, '', this.pageSize)
    );
  }

  ngOnInit(): void {}

  searchProduto(searchDto: SearchDto) {
    return this._searchService.searchProduto(searchDto).subscribe({
      next: (data: Produto[]) => {
        this.result =  data;
        console.log(this.result);
      },

      error: (err: HttpErrorResponse) => {
        this.erro = err.error;
      },
    });
  }
}