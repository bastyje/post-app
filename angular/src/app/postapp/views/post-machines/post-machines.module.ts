import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostMachinesRoutingModule } from './post-machines-routing.module';
import { PostMachineListComponent } from './pages/post-machine-list/post-machine-list.component';
import { PostMachineDetailComponent } from './pages/post-machine-detail/post-machine-detail.component';
import {FormsModule} from "@angular/forms";
import {PostappModule} from "../../postapp.module";
import { NgxPermissionsModule } from "ngx-permissions";


@NgModule({
  declarations: [
    PostMachineListComponent,
    PostMachineDetailComponent
  ],
    imports: [
        CommonModule,
        PostMachinesRoutingModule,
        FormsModule,
        PostappModule,
        NgxPermissionsModule
    ]
})
export class PostMachinesModule { }
