import { Component, Input } from '@angular/core';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-deleting-modal',
  templateUrl: './deleting-modal.component.html',
  styleUrls: ['./deleting-modal.component.css'],
})
export class DeletingModalComponent {
  showModal: boolean = false;
  @Input() id: number;
  @Input() type: string;
  constructor(private itemService: ItemService) {}

  toggle() {
    this.showModal = !this.showModal;
  }
  Delete() {
    this.toggle();
    if (this.type === 'item') {
      this.itemService.DeleteItem(this.id).subscribe({
        next: (response) => {
          console.log(response);
          this.itemService.refresh.next();
        },
      });
    }
  }
}
