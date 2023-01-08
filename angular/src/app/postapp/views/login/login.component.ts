import { Component, OnInit } from '@angular/core';
import {ConfigService} from "../../services/config/config.service";
import { AuthenticationService } from "../../services/authentication.service";
import { LoginModel } from "../../models/LoginModel";
import { Router } from "@angular/router";
import { ErrorMessage } from "../../models/error-message";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: LoginModel = <LoginModel>{};
  errorMessages: ErrorMessage[] = [];

  constructor(private router: Router, private authenticationService: AuthenticationService) {}

  ngOnInit(): void {}

  login(): void {
    this.authenticationService.signIn(this.loginModel).catch(e => {
      if (e.status === 400) {
        this.errorMessages.push({
          message: "Wrong username or password"
        });
      }
    });
  }
}
