import { UsersService } from './../../../../modules/users-api/api/users.service';
import { Users } from '../../../../modules/users-api/model/users';
import { Component, Input } from '@angular/core';
import { MatDialog, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { GetStatsComponent } from '../get-stats/get-stats.component';

@Component({
  selector: 'app-users-tables',
  templateUrl: './users-tables.component.html',
  styleUrls: ['./users-tables.component.scss']
})
export class UsersTablesComponent {

  public displayedColumns: string[] = ['id', 'name', 'active'];
  public activityCounter: number;

  @Input()
  public users: Users;

  constructor(public dialog: MatDialog,
              private usersService: UsersService) { }

  public getStats(): void {
    const dialogRef = this.dialog.open(GetStatsComponent, {
      width: "500px",
      data: this.users
    });
  }

  public updateUserActive(user: Users){
    this.usersService.updateUser(user)
    .subscribe(resp => {
      this.users.active = user.active;
    });
  }
}
