import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-mi-modal',
  templateUrl: './mi-modal.component.html',
  styleUrls: ['./mi-modal.component.css']
})
export class MiModalComponent {
  constructor(
    public dialogRef: MatDialogRef<MiModalComponent>) { }
  onNoClick(): void {
    this.dialogRef.close();
  }
  ngOnInit() {
  }
}
