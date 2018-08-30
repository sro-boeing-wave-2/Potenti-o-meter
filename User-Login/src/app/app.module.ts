import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {MatButtonModule, MatCheckboxModule ,MatCardModule,MatIconModule,
  MatToolbarModule,MatDialogModule, MatDialogRef} from '@angular/material';
import { AppComponent } from './app.component';
import { UserLoginComponent } from './user-login/user-login.component';
import { HomeComponent } from './home/home.component';
import { UserSignUpComponent } from './user-sign-up/user-sign-up.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    UserLoginComponent,
    HomeComponent,
    UserSignUpComponent
  ],
  entryComponents: [UserLoginComponent,UserSignUpComponent],
  imports: [
    BrowserModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatIconModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
