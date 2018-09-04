import { Injectable } from '@angular/core';
import {UserResult} from '../UserResult';
import {Http} from '@angular/http';

@Injectable({
  providedIn: 'root'
})
export class ResultService {
  _Result : UserResult;

  getUserResult(UserId,DomainName){
    return this.http.get("https://localhost:44343/api/QuizResult?userId="+UserId+"&domainName="+DomainName);
  }

  constructor(private http : Http) { }
}
