import { Users } from './../../../../modules/users-api/model/users';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent {

  public displayedColumns: string[] = ['id', 'name', 'active'];

  @Input()
  public users: Users;

  constructor() { }

}
