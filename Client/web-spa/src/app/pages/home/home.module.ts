import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomePage } from './home.page';
import { UsersListComponent } from './components/users-list/users-list.component';
import { UsersItemComponent } from './components/users-item/users-item.component';

@NgModule({
  declarations: [
    HomePage,
    UsersListComponent,
    UsersItemComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
