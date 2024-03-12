import { Injectable } from '@angular/core';
import Swal from 'sweetalert2';

Injectable({ providedIn: 'root' });
export class SweatAlert {
  tinyAlert() {
    Swal.fire('Hey there!');
  }

  successNotification(isUpdateMode: boolean) {
    if (isUpdateMode) {
      Swal.fire('UPDATED!', 'ITEM UPDATED SUCCESSFULLY', 'success');
    } else {
      Swal.fire('CREATED!', 'ITEM CREATED SUCCESSFULLY', 'success');
    }
  }

  alertConfirmation() {
    Swal.fire({
      title: 'Are you sure?',
      text: 'This process will be canceled!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, go ahead.',
      cancelButtonText: 'No, let me think',
    }).then((result) => {
      if (result.value) {
        Swal.fire('Removed!', 'Product removed successfully.', 'success');
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire('Cancelled', 'Product still in our database.)', 'error');
      }
    });
  }

  alertSkipEdit(): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      Swal.fire({
        title: 'Are You Sure?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Yes',
        cancelButtonText: 'Cancel',
      }).then((result) => {
        if (result.value) {
          resolve(true);
        } else if (result.dismiss === Swal.DismissReason.cancel) {
          resolve(false);
        }
      });
    });
  }
}
