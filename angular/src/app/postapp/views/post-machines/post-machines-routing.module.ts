import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PostMachineDetailComponent } from './pages/post-machine-detail/post-machine-detail.component';
import { PostMachineListComponent } from './pages/post-machine-list/post-machine-list.component';

const routes: Routes = [
  {
    path: '',
    component: PostMachineListComponent
  },
  {
    path: 'edit/:id',
    component: PostMachineDetailComponent
  },
  {
    path: 'add',
    component: PostMachineDetailComponent
  },
  {
    path: ':id',
    component: PostMachineDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PostMachinesRoutingModule { }
