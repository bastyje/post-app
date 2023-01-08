import { Injectable } from "@angular/core";
import { AuthConfig, OAuthService } from "angular-oauth2-oidc";
import { ConfigService } from "./config.service";

export const oAuthConfig: AuthConfig = {
  clientId: 'AngularSPA',
  dummyClientSecret: 'secret',
  requireHttps: false,
  oidc: false
};

@Injectable()
export class OAuthConfig {

  constructor(private configService: ConfigService, private oAuthService: OAuthService) {}

  load(): Promise<object> {
    let url: string;
    oAuthConfig.issuer = this.configService.config().issuer;

    this.oAuthService.configure(oAuthConfig);
    url = oAuthConfig.issuer + '/.well-known/openid-configuration';

    this.oAuthService.setStorage(localStorage);
    return this.oAuthService.loadDiscoveryDocument(url);
  }
}
