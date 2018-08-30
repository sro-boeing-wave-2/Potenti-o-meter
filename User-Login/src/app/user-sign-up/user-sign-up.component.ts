import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormArray } from '@angular/forms';
import { MatDialogRef,MatDialog } from '@angular/material';
import {UserLoginComponent} from '../user-login/user-login.component';
@Component({
  selector: 'app-user-sign-up',
  templateUrl: './user-sign-up.component.html',
  styleUrls: ['./user-sign-up.component.css']
})
export class UserSignUpComponent implements OnInit {

  constructor( private fb: FormBuilder,private dialog: MatDialog,
    public dialogRef: MatDialogRef<UserSignUpComponent>) { }

  ngOnInit() {
  }
  CreateSignUpForm = this.fb.group({
    FirstName:[''],
    LastName:[''],
    Email : [''],
    Password: [''],
    ConfirmPassword:['']
  });
  onSubmit():void{
  }
  Close(){
    this.dialogRef.close();
  }
 
}
