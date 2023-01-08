import { Component, OnInit } from '@angular/core';
import {PostMachineService} from "../../services/post-machine.service";
import {CreatePackageCommand} from "../../models/create-package-command";
import {UserService} from "../../services/user.service";
import {CreatePostMachineCommand} from "../../models/create-post-machine-command";
import {PackageService} from "../../services/package.service";
import {PaginationRequest} from "../../models/pagination-request";
import { ErrorMessage } from "../../models/error-message";

@Component({
  selector: 'app-send-package',
  templateUrl: './send-package.component.html',
  styleUrls: ['./send-package.component.scss']
})
export class SendPackageComponent implements OnInit {

  packages: any[] = [];
  postMachines: any[] = [];
  postMachine: any = {};
  username: string = '';
  errorMessages: ErrorMessage[] = [];
  success: boolean = false;
  receiveErrorMessages: any[] = [];

  constructor(private postMachineService: PostMachineService, private packageService: PackageService) {}

  ngOnInit(): void {
    this.postMachineService
      .getPostMachines(<PaginationRequest> {pageSize: 10, currentPage: 1})
      .subscribe(r => this.postMachines = r.content.postMachines.content);
    this.packageService.getMyReady().subscribe(r => {
      if (r.success) {
        this.packages = r.content
      } else {
        this.receiveErrorMessages = r.errorMessages;
      }
    });
  }

  send(): void {
    this.success = false;
    this.packageService.addPackage(<CreatePackageCommand> {
      addresseeId: this.username,
      postMachineId: this.postMachine.id,
      senderId: ''
    }).subscribe(r => {
      if (r.success) {
        this.success = true;
      } else {
        this.errorMessages = r.errorMessages;
      }
    });
  }

  onClick(item: any): void {
    this.username = item.username;
  }

  receive(pack: any): void {
    this.packageService.receive(pack.id).subscribe(_ => {
      this.packageService.getMyReady().subscribe(r => {
        this.packages = [];
        if (r.success) {
          this.packages = r.content
        } else {
          this.receiveErrorMessages = r.errorMessages;
        }
      });
    });
  }
}
