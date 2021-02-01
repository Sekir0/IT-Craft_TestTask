import { ConfirmDialogModel } from './../../../../modules/users-api/model/confirm-dialog.model';
import { Component, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-get-stats',
  templateUrl: './get-stats.component.html',
  styleUrls: ['./get-stats.component.scss']
})
export class GetStatsComponent {

  constructor(
    public dialogRef: MatDialogRef<GetStatsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmDialogModel
  )
  { }

  onDismiss(): void {
    this.dialogRef.close(false);
  }

  public get getActive(): number {
    let active = 0;
    for (let i = 0; i < this.data.users.length; i++){
      if(this.data.users[i].active){
        active++;
      }
    }
    return active;
  }
}
