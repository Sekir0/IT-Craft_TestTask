import { UserUpdateViewModel } from './../model/userUpdateViewModel';
import { Users } from './../model/users';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class UsersService {
  private readonly basePath = 'https://localhost:5001/Users'

  constructor(private httpClient: HttpClient) {}

  public getUsers(): Observable<any>{
    return this.httpClient.get<Users>(`${this.basePath}`);
  }

  public getUser(user: Users) {
    return this.httpClient.get(`${this.basePath}/${user.id}`);
  }

  public updateUser(user: Users) {
    return this.httpClient.put(`${this.basePath}/${user.id}`, {
      active: user.active
    });
  }
}
