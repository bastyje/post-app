import { Injectable } from '@angular/core';
import { OAuthService } from "angular-oauth2-oidc";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { Router } from "@angular/router";
import { ServiceMessage } from "../models/service-message";
import { LoginModel } from "../models/LoginModel";
import { RegisterUserCommand } from "../models/register-user-command";
import { NgxPermissionsService } from "ngx-permissions";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    private oAuthService: OAuthService,
    private httpService: HttpService,
    private router: Router,
    private permissionsService: NgxPermissionsService) {}

  public signIn(login: LoginModel): Promise<void | object> {
    return this.oAuthService
      .fetchTokenUsingPasswordFlowAndLoadUserProfile(login.username, login.password)
      .then(_ => {
        let permissions = this.oAuthService.getIdentityClaims()['permission'];
        if (!(permissions instanceof Array))
          permissions = [permissions];
        this.permissionsService.loadPermissions(permissions);
        this.router.navigate(['/']);
      })
  }

  public signOut() {
    this.oAuthService.logOut(true);
    this.router.navigate(['/', 'login']);
  }

  public register(registerUserModel: RegisterUserCommand): Observable<ServiceMessage> {
    return this.httpService.post('User', registerUserModel);
  }

  public isLoggedIn(): boolean {
    const expireTime = localStorage.getItem('expires_at');
    let loggedIn = false;
    if (expireTime !== null)
      loggedIn = parseInt(expireTime) > Date.now();
    return loggedIn;
  }

  public getToken(): string {
    const token: string = this.oAuthService.getAccessToken();
    return token;
  }
}
