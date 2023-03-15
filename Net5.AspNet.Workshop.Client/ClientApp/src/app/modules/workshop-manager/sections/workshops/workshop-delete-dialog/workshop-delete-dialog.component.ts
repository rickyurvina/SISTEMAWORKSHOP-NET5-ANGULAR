import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Workshop } from '../../../../../models/workshop';

@Component({
  selector: 'app-workshop-delete-dialog',
  templateUrl: './workshop-delete-dialog.component.html',
  styleUrls: ['./workshop-delete-dialog.component.scss']
})
export class WorkshopDeleteDialogComponent implements OnInit {
  message: string = "";

  constructor(
    public _dialogRef: MatDialogRef<WorkshopDeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Workshop
  ) {
    _dialogRef.disableClose = true;
  }

  ngOnInit(): void {
    this.message = this.data.Title;
  }

  btnCloseOnClick(): void {
    this._dialogRef.close();
  }

  btnDeleteOnClick(): void {
    this._dialogRef.close(this.data.WorkshopId);
  }

}
