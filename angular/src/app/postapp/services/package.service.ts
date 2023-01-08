import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpService} from "./http.service";
import {CreatePackageCommand} from "../models/create-package-command";
import {UpdatePackageStatusCommand} from "../models/update-package-status-command";
import {PaginationRequest} from "../models/pagination-request";
import { ServiceMessage } from "../models/service-message";

@Injectable({
  providedIn: 'root'
})
export class PackageService {

  private controller: string = 'Package';

  constructor(private http: HttpService) { }

  getPackage(id: number): Observable<any> {
    return this.http.get(`${this.controller}/${id}`);
  }

  getPackages(paginationData: PaginationRequest): Observable<any> {
    return this.http.get(`${this.controller}?pageSize=${paginationData.pageSize}&currentPage=${paginationData.currentPage}`);
  }

  addPackage(createPackageCommand: CreatePackageCommand): Observable<ServiceMessage> {
    return this.http.post<ServiceMessage>(`${this.controller}`, createPackageCommand);
  }

  updatePackageStatus(updatePackageStatusCommand: UpdatePackageStatusCommand): Observable<any> {
    return this.http.put(`${this.controller}`, updatePackageStatusCommand);
  }

  getMyReady(): Observable<any> {
    return this.http.get(`${this.controller}/my`)
  }

  receive(id: number): Observable<any> {
    return this.http.delete(`${this.controller}/${id}`)
  }
}
