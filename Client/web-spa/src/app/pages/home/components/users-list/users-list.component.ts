import { Users } from './../../../../modules/users-api/model/users';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.css']
})
export class UsersListComponent {

  @Input()
  public users: Users;

  constructor() { }

}
