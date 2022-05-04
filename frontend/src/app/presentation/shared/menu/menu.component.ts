import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  selected?: string = "";
  states: string[] = [
    'Furadeira',
    'Mouse',
  ];
  
  constructor() { }

  ngOnInit(): void {
  }

  isCollapsed = false;
  message = 'expanded';
 
  collapsed(): void {
    this.message = 'collapsed';
  }
 
  collapses(): void {
    this.message = 'collapses';
  }
 
  expanded(): void {
    this.message = 'expanded';
  }
 
  expands(): void {
    this.message = 'expands';
  }

}
