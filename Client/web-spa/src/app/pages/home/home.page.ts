import { Users } from './../../modules/users-api/model/users';
import { UsersService } from './../../modules/users-api/api/users.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss']
})
export class HomePage implements OnInit {

  public users: Users;

  constructor(private usersService: UsersService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  public loadUsers(): void {
    this.usersService.usersGet().subscribe(resp => {
      this.users = resp;
    })
  }

}
