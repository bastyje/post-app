import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpService} from "./http.service";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  controller: string = 'User';

  constructor(private http: HttpService) { }

  getUserByUsername(username: string): Observable<any> {
    return this.http.get(`${this.controller}/${username}`);
  }

  getUserByNamePattern(pattern: string): Observable<any> {
    return this.http.get(`${this.controller}/pattern?pattern=${pattern}`);
  }
}
