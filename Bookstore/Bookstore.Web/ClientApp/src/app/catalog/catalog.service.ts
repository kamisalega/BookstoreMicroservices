import {Injectable} from '@angular/core';

import {ConfigurationService} from "../shared/services/configuration.service";
import {DataService} from "../shared/services/data.service";
import {ICatalog} from "../shared/models/catalog.model";
import {ICatalogCategory} from "../shared/models/catalogCategory.model";

import {Observable} from "rxjs";
import {tap} from "rxjs/operators";

@Injectable()
export class CatalogService {
  private catalogUrl: string = '';
  private categoryUrl: string = '';

  constructor(private service: DataService, private configurationService: ConfigurationService) {
    this.configurationService.settingsLoaded$.subscribe(x => {
      this.catalogUrl = this.configurationService.serverSettings.purchaseUrl + '/api/books';
      this.categoryUrl = this.configurationService.serverSettings.purchaseUrl + '/api/categories';
    });
  }

  getCatalog(pageIndex: number, pageSize: number, category: string, type: number): Observable<ICatalog> {
    if (this.catalogUrl === '') {
      this.catalogUrl = this.catalogUrl = this.configurationService.serverSettings.purchaseUrl + '/api/books';
    }

    let url = this.catalogUrl;

    if (type) {
      // url = this.catalogUrl + '/type/' + type.toString() + '/brand/' + ((brand) ? brand.toString() : '');
    } else if (category) {
      url = this.categoryUrl + '/' + ((category) ? category.toString() : '');
    }

    url = url + '?pageIndex=' + pageIndex + '&pageSize=' + pageSize;

    return this.service.get(url).pipe<ICatalog>(tap((response: any) => {
      console.log(response);
      return response;
    }));
  }

  getCategories(): Observable<ICatalogCategory[]> {
    return this.service.get(this.categoryUrl).pipe<ICatalogCategory[]>(tap((response: any) => {
      return response;
    }));
  }
}
