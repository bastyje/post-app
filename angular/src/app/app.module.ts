import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {ConfigModule} from "./postapp/services/config/config.module";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { OAuthModule } from 'angular-oauth2-oidc';
import { JwtInterceptor } from "./postapp/services/jwt.interceptor";
import { NgxPermissionsModule, NgxPermissionsService } from "ngx-permissions";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ConfigModule,
    OAuthModule.forRoot(),
    NgxPermissionsModule.forRoot(),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
