import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostappRoutingModule } from './postapp-routing.module';
import { LayoutComponent } from './views/shared/layout/layout.component';
import { FooterComponent } from './views/shared/layout/footer/footer.component';
import { NavbarComponent } from './views/shared/layout/navbar/navbar.component';
import { SendPackageComponent } from './views/send-package/send-package.component';
import { LoginComponent } from './views/login/login.component';
import { PaginationComponent } from './views/shared/components/pagination/pagination.component';
import { SearchFilterComponent } from './views/shared/components/search-filter/search-filter.component';
import {FormsModule} from "@angular/forms";
import { RegisterComponent } from './views/register/register.component';


@NgModule({
  declarations: [
    LayoutComponent,
    FooterComponent,
    NavbarComponent,
    SendPackageComponent,
    LoginComponent,
    PaginationComponent,
    SearchFilterComponent,
    RegisterComponent
  ],
  exports: [
    LayoutComponent,
    FooterComponent,
    NavbarComponent,
    PaginationComponent
  ],
    imports: [
        CommonModule,
        FormsModule,
        PostappRoutingModule
    ]
})
export class PostappModule { }
