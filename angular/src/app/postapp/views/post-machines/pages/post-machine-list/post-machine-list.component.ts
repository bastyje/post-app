import { Component, OnInit } from '@angular/core';
import {PostMachineService} from "../../../../services/post-machine.service";
import {PaginationRequest} from "../../../../models/pagination-request";
import {PaginationResponse} from "../../../../models/pagination-response";
import { Permission } from "../../../../enums/permission";

@Component({
  selector: 'app-post-machine-list',
  templateUrl: './post-machine-list.component.html',
  styleUrls: ['./post-machine-list.component.scss']
})
export class PostMachineListComponent implements OnInit {

  constructor(private postMachineService: PostMachineService) {}

  postMachines: PaginationResponse<any> = {} as PaginationResponse<any>;
  paginationData: PaginationResponse<any> = {
    pageSize: 10,
    currentPage: 1
  } as PaginationResponse<any>;
  Permission = Permission;

  ngOnInit(): void {
    this.search();
  }

  onPaginationChanged(paginationData: PaginationRequest): void {
    this.paginationData.currentPage = paginationData.currentPage;
    this.paginationData.pageSize = paginationData.pageSize;
    this.search();
  }

  search(): void {
    this.postMachineService.getPostMachines(this.paginationData).subscribe(r => {
      this.paginationData = <PaginationResponse<any>> {
        pageSize: r.content.postMachines.pageSize,
        currentPage: r.content.postMachines.currentPage,
        lastPage: r.content.postMachines.lastPage,
        totalItems: r.content.postMachines.totalItems,
      };
      this.postMachines = r.content.postMachines;
    })
  }
}
