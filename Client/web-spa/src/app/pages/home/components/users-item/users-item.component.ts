import { Users } from './../../../../modules/users-api/model/users';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-users-item',
  templateUrl: './users-item.component.html',
  styleUrls: ['./users-item.component.css']
})
export class UsersItemComponent {

  @Input()
  public user: Users;

  constructor() { }

}
