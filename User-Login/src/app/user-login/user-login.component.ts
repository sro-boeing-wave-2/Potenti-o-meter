import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray } from '@angular/forms';
import { MatDialogRef,MatDialog } from '@angular/material';
import{UserSignUpComponent } from '../user-sign-up/user-sign-up.component'
import {Router} from '@angular/router';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {

  constructor( private fb: FormBuilder,private dialog: MatDialog,
    public dialogRef: MatDialogRef<UserLoginComponent>,private router: Router) { }

  ngOnInit() {
  }
  CreateLoginForm = this.fb.group({
    Email : [''],
    Password: ['']
  });
  onSubmit():void{
    this.router.navigate(['home']);
    this.Close();
  }
  Close(){
    this.dialogRef.close();
  }
  SignUp() {
    this.Close();
    let dialog = this.dialog.open(UserSignUpComponent,{ width:'600px',panelClass: 'my-centered-dialog' });
    
  }
}
