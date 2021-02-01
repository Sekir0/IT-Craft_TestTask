import { UsersService } from './../../../../modules/users-api/api/users.service';
import { Users } from '../../../../modules/users-api/model/users';
import { Component, Input } from '@angular/core';

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

  constructor(private usersService: UsersService) { }


  public updateUserActive(user: Users){
    this.usersService.updateUser(user)
    .subscribe(resp => {
    });
  }
}
