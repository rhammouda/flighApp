import { Injectable, Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  urlApi = 'http://localhost:5000/api';

  constructor() { }

}


@Injectable({
  providedIn: 'root'
})
export class AlertService {
  constructor(private dialog: MatDialog) { }

  show(title: string, text: string): void {
    const dialogRef = this.dialog.open(AlertMessageDialogComponent, {
      width: '250px',
      data: {title: title, text: text}
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

}


@Component({
  selector: 'app-alert-message-dialog',
  template: `
        <h1 mat-dialog-title>{{data.title}}</h1>
      <div mat-dialog-content>
        <p>{{data.text}}</p>
      </div>
      <div mat-dialog-actions align="end">
        <button mat-button cdkFocusInitial  (click)="close()">Ok</button>
      </div>
  `
})
export class AlertMessageDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<AlertMessageDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: AlertMessageData) {}

  close(): void {
    this.dialogRef.close();
  }

}

interface AlertMessageData {
  title: string;
  text: string;
}


