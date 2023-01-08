import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './views/shared/layout/layout.component';
import {SendPackageComponent} from "./views/send-package/send-package.component";
import {LoginComponent} from "./views/login/login.component";

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [{
        path: '',
        component: SendPackageComponent,
        data: {
          title: 'Send package'
        }
      }, {
        path: 'post-machine',
        loadChildren: () => import('./views/post-machines/post-machines.module').then(m => m.PostMachinesModule),
        data: {
          title: 'Post machines'
        }
      }, {
        path: 'package',
        loadChildren: () => import('./views/packages/packages.module').then(m => m.PackagesModule),
        data: {
          title: 'Packages'
        }
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PostappRoutingModule { }
