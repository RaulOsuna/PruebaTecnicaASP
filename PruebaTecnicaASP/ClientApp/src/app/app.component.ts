import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MiModalComponent } from './mi-modal/mi-modal.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  name: string="";
  color: string="";
  constructor(public dialog: MatDialog) { }
  openDialog(): void {
    const dialogRef = this.dialog.open(MiModalComponent, {
      width: '250px',
      data: { name: this.name, color: this.color }
    });
    dialogRef.afterClosed().subscribe(res => {
      this.color = res;
    });
  }
}
