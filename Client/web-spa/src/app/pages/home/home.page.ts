import { Users } from './../../modules/users-api/model/users';
import { UsersService } from './../../modules/users-api/api/users.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { GetStatsComponent } from './components/get-stats/get-stats.component';
import { ConfirmDialogModel } from '../../modules/users-api/model/confirm-dialog.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss']
})
export class HomePage implements OnInit {

  public users: Users[] = [];

  constructor(private usersService: UsersService,
    public dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  public getStats(): void {
    const usersData = this.users;

    const dialogData = new ConfirmDialogModel(usersData);

    const dialogRef = this.dialog.open(GetStatsComponent, {
      width: "500px",
      data: dialogData
    });
  }

  public loadUsers(): void {
    this.usersService.getUsers().subscribe(resp => {
      this.users = resp;
    })
  }

  public onPublished(user: Users): void {
    this.loadUsers();
  }
}
