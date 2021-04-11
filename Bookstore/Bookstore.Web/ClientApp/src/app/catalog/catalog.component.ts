import {Component, OnInit} from '@angular/core';

import {ConfigurationService} from "../shared/services/configuration.service";
import {CatalogService} from "./catalog.service";

import {ICatalog} from "../shared/models/catalog.model";
import {IPager} from "../shared/models/pager.model";
import {ICatalogCategory} from "../shared/models/catalogCategory.model";

import {Observable, Subscription} from "rxjs";
import {catchError} from "rxjs/operators";
import {ICatalogItem} from "../shared/models/catalogItem.model";
import {BasketWrapperService} from "../shared/services/basket.wrapper.service";


@Component({
  selector: 'bs-catalog .bs-catalog',
  templateUrl: './catalog.component.html',
  styleUrls: ['./catalog.component.scss']
})
export class CatalogComponent implements OnInit {
  categories: ICatalogCategory[];
  // types: ICatalogType[];
  catalog: ICatalog;
  categorySelected: string;
  typeSelected: number;
  paginationInfo: IPager;
  authenticated: boolean = false;
  authSubscription: Subscription;
  errorReceived: boolean;

  constructor(
    private service: CatalogService,
    private basketService: BasketWrapperService,
    private configurationService: ConfigurationService,
    // private securityService: SecurityService
  ) {
  }

  ngOnInit(): void {
    if (this.configurationService.isReady)
      this.loadData();
    else
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.loadData();
      });

    // Subscribe to login and logout observable
    // this.authSubscription = this.securityService.authenticationChallenge$.subscribe(res => {
    //   this.authenticated = res;
    // });
  }

  loadData() {
    this.getCategories();
    this.getCatalog(10, 0);
    //this.getTypes();
  }

  onFilterApplied(event: any) {
    event.preventDefault();
    this.getCatalog(this.paginationInfo.itemsPage, this.paginationInfo.actualPage, this.categorySelected, this.typeSelected);
  }

  onCategoryFilterChanged(event: any, value: string) {
    event.preventDefault();
    this.categorySelected = value;
  }

  onTypeFilterChanged(event: any, value: number) {
    event.preventDefault();
    this.typeSelected = value;
  }

  onPageChanged(value: any) {
    console.log('catalog pager event fired' + value);
    event.preventDefault();
    this.paginationInfo.actualPage = value;
    this.getCatalog(this.paginationInfo.itemsPage, value);
  }

  addToCart(item: ICatalogItem) {
    this.basketService.addItemToBasket(item);
  }

  getCatalog(pageSize: number, pageIndex: number, category?: string, type?: number) {
    this.errorReceived = false;
    this.service.getCatalog(pageIndex, pageSize, category, type)
      .pipe(catchError((err) => this.handleError(err)))
      .subscribe(catalog => {
        this.catalog = catalog;
        this.paginationInfo = {
          actualPage: catalog.pageIndex,
          itemsPage: catalog.pageSize,
          totalItems: catalog.count,
          totalPages: Math.ceil(catalog.count / catalog.pageSize),
          items: catalog.pageSize
        };
      });
  }

  // getTypes() {
  //   this.service.getTypes().subscribe(types => {
  //     this.types = types;
  //     let alltypes = { id: null, type: 'All' };
  //     this.types.unshift(alltypes);
  //   });
  // }

  getCategories() {
    this.service.getCategories().subscribe(categories => {
      this.categories = categories;
      let allCategories = {categoryId: null, name: 'Wszystkie'};
      this.categories.unshift(allCategories);
    });
  }

  private handleError(error: any) {
    this.errorReceived = true;
    return Observable.throw(error);
  }


}
