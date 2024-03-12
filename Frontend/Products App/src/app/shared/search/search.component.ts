import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent {
  searchContent: string = '';

  @Output() search: EventEmitter<string> = new EventEmitter<string>();

  onSearch(search: HTMLInputElement) {
    this.searchContent = search.value;
    this.search.emit(this.searchContent);
  }
}
