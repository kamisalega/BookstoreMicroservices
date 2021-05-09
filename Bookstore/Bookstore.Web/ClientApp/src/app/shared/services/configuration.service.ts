import {Injectable, OnInit} from '@angular/core';
import {IConfiguration} from "../models/configuration.model";
import {Subject} from "rxjs";
import {HttpClient} from "@angular/common/http";
import {StorageService} from "./storage.service";

@Injectable()
export class ConfigurationService {
  serverSettings: IConfiguration;

  private settingsLoadedSource = new Subject();
  settingsLoaded$ = this.settingsLoadedSource.asObservable();
  isReady: boolean = false;

  constructor(private http: HttpClient, private _storageService: StorageService) {
  }

  load() {
    const baseURI = document.baseURI.endsWith('/') ? document.baseURI : `${document.baseURI}/`;
    let url = `${baseURI}api/home/configuration`;
    this.http.get(url).subscribe((response) => {
      console.log('server settings loaded');
      this.serverSettings = response as IConfiguration;
      console.log(this.serverSettings);
      this._storageService.store('bookCatalogUrl', this.serverSettings.bookCatalogUrl);
       this._storageService.store('shoppingBasketUrl', this.serverSettings.shoppingBasketUrl);
      this._storageService.store('orderUrl', this.serverSettings.orderUrl);
      this._storageService.store('identityUrl', this.serverSettings.identityUrl);
      this._storageService.store('activateCampaignDetailFunction', this.serverSettings.activateCampaignDetailFunction);
      this.isReady = true;
      this.settingsLoadedSource.next();
    });
  }
}
