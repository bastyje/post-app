import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpService} from "./http.service";
import {CreatePostMachineCommand} from "../models/create-post-machine-command";
import {UpdatePostMachineCommand} from "../models/update-post-machine-command";
import {DeletePostMachineCommand} from "../models/delete-post-machine-command";
import {PaginationRequest} from "../models/pagination-request";

@Injectable({
  providedIn: 'root'
})
export class PostMachineService {

  private controller: string = 'PostMachine';

  constructor(private http: HttpService) { }

  getPostMachine(id: number): Observable<any> {
    return this.http.get(`${this.controller}/${id}`);
  }

  getPostMachines(paginationRequest: PaginationRequest): Observable<any> {
    return this.http.get(`${this.controller}?pageSize=${paginationRequest.pageSize}&currentPage=${paginationRequest.currentPage}`);
  }

  createPostMachine(createPostMachineCommand: CreatePostMachineCommand): Observable<any> {
    return this.http.post(`${this.controller}`, createPostMachineCommand);
  }

  updatePostMachine(updatePostMachineCommand: UpdatePostMachineCommand): Observable<any> {
    return this.http.put(`${this.controller}`, updatePostMachineCommand);
  }

  deletePostMachine(deletePostMachineCommand: DeletePostMachineCommand): Observable<any> {
    return this.http.delete(`${this.controller}`, deletePostMachineCommand);
  }
}
