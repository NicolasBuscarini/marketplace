export class SearchDto {
  
  pageNumber: number;
  searchString: string;
  pageSize: number;

  constructor(pageNumber: number, searchString: string, pageSize: number) {
    this.pageNumber = pageNumber;
    this.searchString = searchString;
    this.pageSize = pageSize;
  }
}
