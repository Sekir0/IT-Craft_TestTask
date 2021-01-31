import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { HomePage } from './home.page';
import { UsersTablesComponent } from './components/users-table/users-tables.component';
import { ConfirmDialogComponent } from './components/confirm-dialog/confirm-dialog.component';
import { UsersListComponent } from './components/users-list/users-list.component'


@NgModule({
  declarations: [
    HomePage,
    UsersTablesComponent,
    ConfirmDialogComponent,
    UsersListComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatButtonModule,
    MatCheckboxModule,
    FormsModule,
    MatDialogModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatCardModule
  ]
})
export class HomeModule { }
