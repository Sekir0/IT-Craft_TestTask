import { Users } from '../../../../modules/users-api/model/users';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-users-tables',
  templateUrl: './users-tables.component.html',
  styleUrls: ['./users-tables.component.scss']
})
export class UsersTablesComponent {

  public displayedColumns: string[] = ['id', 'name', 'active'];

  @Input()
  public users: Users;

  constructor() { }

}
