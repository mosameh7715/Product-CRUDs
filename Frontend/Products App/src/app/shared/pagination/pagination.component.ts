import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  SimpleChanges,
} from '@angular/core';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrls: ['./pagination.component.css'],
})
export class PaginationComponent implements OnInit, OnChanges {
  @Input() totalCount: number = 30;
  @Input() currentPage: number = 1;
  @Output() changeCurrentPage: EventEmitter<number> =
    new EventEmitter<number>();

  totalPages: number = 30;
  // Adding Dots in case of more than 10 pages
  startPage: number = Math.max(1, this.currentPage - 4);
  endPage: number = Math.min(this.totalPages, this.startPage + 9);
  ngOnInit() {}
  ngOnChanges(changes: SimpleChanges): void {
    this.totalPages = Math.ceil(this.totalCount / 9);
    this.startPage = Math.max(1, this.currentPage - 4);
    this.endPage = Math.min(this.totalPages, this.startPage + 9);
  }

  onChangeCurrentPage(page: number) {
    this.currentPage = page;
    this.startPage = Math.max(1, this.currentPage - 4);
    this.endPage = Math.min(this.totalPages, this.startPage + 9);
    this.changeCurrentPage.emit(page);
  }
}
