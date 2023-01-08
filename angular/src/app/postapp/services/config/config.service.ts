

import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from "rxjs";
import { Config } from "../../interfaces/config";

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  private appConfig: Config;
  private http: HttpClient;

  constructor(handler: HttpBackend) {
    this.http = new HttpClient(handler);
    this.appConfig = {} as Config;
  }

  loadConfig() {
    const jsonFile = 'assets/app.config.json';
    return this.http.get(jsonFile).pipe(catchError(() => {
      throw new Error(`Application could not load configuration file '${jsonFile}'`);
    })).
    pipe(map(appConfig => {
      this.appConfig = <Config> appConfig;
    }));

  }

  config(): Config {
    return this.appConfig;
  }
}
