import { Component, Inject, Input } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ConfirmDialogModel } from '../../../../modules/users-api/model/confirm-dialog.model';

@Component({
  selector: 'app-get-stats',
  templateUrl: './get-stats.component.html',
  styleUrls: ['./get-stats.component.scss']
})
export class GetStatsComponent {

  public activityCounter: number;
  public arrLenght: number;

  constructor(
    public dialogRef: MatDialogRef<GetStatsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ConfirmDialogModel
  ) { }

  onDismiss(): void {
    this.dialogRef.close(false);
  }

  public get getActive(): number {
    let count = 0;
    for (let i = 0; i < this.data.length; i++){
      if(this.data[i].active){
        count++;
      }
    }
    return count;
  }
}
