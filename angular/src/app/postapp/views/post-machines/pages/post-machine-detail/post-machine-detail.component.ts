import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from "@angular/router";
import {PostMachineService} from "../../../../services/post-machine.service";
import {UpdatePostMachineCommand} from "../../../../models/update-post-machine-command";
import {CreatePostMachineCommand} from "../../../../models/create-post-machine-command";
import {Location} from "@angular/common";

@Component({
  selector: 'app-post-machine-detail',
  templateUrl: './post-machine-detail.component.html',
  styleUrls: ['./post-machine-detail.component.scss']
})
export class PostMachineDetailComponent implements OnInit {

  constructor(
    private activatedRoute: ActivatedRoute,
    private postMachineService: PostMachineService,
    private location: Location,
    private router: Router) {
    this.activatedRoute.params.subscribe(p => {
      const id = p['id'];
      if (id !== null && id !== undefined) {
        this.postMachineService.getPostMachine(parseInt(id)).subscribe(r => this.postMachine = <UpdatePostMachineCommand>r.content);
        if (router.url.includes('edit')) {
          this.isEdit = true;
        } else {
          this.isPreview = true;
        }
      }
    });
  }

  isEdit: boolean = false;
  isPreview: boolean = false;

  postMachine: UpdatePostMachineCommand = {
    id: 0,
    name: '',
    country: '',
    city: '',
    postalCode: '',
    street: '',
    number: '',
    preciseLocation: ''
  }

  ngOnInit(): void {}

  save(): void {
    if (this.isEdit) {
      this.postMachineService.updatePostMachine(this.postMachine as UpdatePostMachineCommand).subscribe(() => this.location.back());
    } else {
      this.postMachineService.createPostMachine(this.postMachine as CreatePostMachineCommand).subscribe(() => this.location.back());
    }
  }

}
