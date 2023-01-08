import { APP_INITIALIZER, NgModule } from '@angular/core';
import { map, take } from 'rxjs';
import { ConfigService } from './config.service';
import { OAuthConfig } from "./oauth.config";

@NgModule({
  providers: [
    ConfigService,
    {
      provide: APP_INITIALIZER,
      multi: true,
      useFactory: (config: ConfigService, oAuthConfig: OAuthConfig) => {
        return () => config.loadConfig().pipe(map(() => oAuthConfig.load()))
      },
      deps: [ConfigService, OAuthConfig]
    },
    OAuthConfig
  ]
})

export class ConfigModule { }
