import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { User } from './User';
import { HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class SignUpService {
  private header: HttpHeaders;
  constructor(private http: Http) {
    this.header = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });

  }

  USerSignUp(user: User) {
    return this.http.post("https://localhost:44397/api/Users", user);
  }
}
