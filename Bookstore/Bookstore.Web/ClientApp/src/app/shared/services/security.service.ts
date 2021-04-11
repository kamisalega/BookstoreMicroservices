import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {StorageService} from "./storage.service";
import {Subject} from "rxjs";
import {ActivatedRoute, Router} from "@angular/router";
import {ConfigurationService} from "./configuration.service";

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  private actionUrl: string;
  private headers: HttpHeaders;
  private storage: StorageService;
  private authenticationSource = new Subject<boolean>();
  authenticationChallenge$ = this.authenticationSource.asObservable();
  private authorityUrl = '';

  constructor(private _http: HttpClient,
              private _router: Router,
              private route: ActivatedRoute,
              private _configurationService: ConfigurationService,
              private _storageService: StorageService)
  {
    this.headers = new HttpHeaders();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Accept', 'application/json');
    this.storage = _storageService;

    this._configurationService.settingsLoaded$.subscribe(x => {
      this.authorityUrl = this._configurationService.serverSettings.identityUrl;
      this.storage.store('IdentityUrl', this.authorityUrl);
    });
  }
}
