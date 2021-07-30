import {Injectable} from '@angular/core';
import {IBasket} from "../shared/models/basket.model";
import {Observable, Subject} from "rxjs";
import {DataService} from "../shared/services/data.service";
import {BasketWrapperService} from "../shared/services/basket.wrapper.service";
import {Router} from "@angular/router";
import {ConfigurationService} from "../shared/services/configuration.service";
import {StorageService} from "../shared/services/storage.service";
import {SecurityService} from "../shared/services/security.service";
import {tap} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private basketUrl: string = '';
  private purchaseUrl: string = '';
  basket: IBasket = {
    buyerId: '',
    items: []
  };
  //observable that is fired when item is removed from basket
  private basketUpdateSource = new Subject();
  basketUpdate$ = this.basketUpdateSource.asObservable();

  constructor(
    private service: DataService,
    private authService: SecurityService,
    private basketWrapperService: BasketWrapperService,
    private router: Router,
    private configurationService: ConfigurationService,
    private storageService: StorageService
  ) {
    this.basket.items = [];

    if (this.authService.IsAuthorized) {
      if (this.authService.UserData) {
        this.basket.buyerId = this.authService.UserData.sub;
        if (this.configurationService.isReady) {
          this.basketUrl = this.configurationService.serverSettings.basketUrl;
          this.purchaseUrl = this.configurationService.serverSettings.purchaseUrl;
          this.loadData();
        } else {
          this.configurationService.settingsLoaded$.subscribe(x => {
            this.basketUrl = this.configurationService.serverSettings.basketUrl;
            this.purchaseUrl = this.configurationService.serverSettings.purchaseUrl;
            this.loadData();
          });
        }
      }
    }

    this.basketWrapperService.orderCreated$.subscribe(x => {
      this.dropBasket();
    });
  }

  addItemToBasket(item): Observable<boolean> {
    let basketItem = this.basket.items.find(value => value.productId == item.productId);

    if (basketItem) {
      basketItem.quantity++;
    } else {
      this.basket.items.push(item);
    }

    return this.setBasket(this.basket);
  }

  getBasket(): Observable<IBasket> {
    let url = this.basketUrl + 'api/baskets/' + this.basket.buyerId;

    return this.service.get(url).pipe<IBasket>(tap((response: any) => {
      if (response.status === 204) {
        return null;
      }

      return response;
    }));
  }

  private setBasket(basket): Observable<boolean> {
    let url = this.basketUrl + 'api/baskets/'

    this.basket = basket;
    return this.service.post(url, basket).pipe<boolean>(tap((response: any) => true));
  }

  private loadData() {
    this.getBasket().subscribe(basket => {
      if (basket != null) {
        this.basket.items = basket.items;
      }
    })
  }

  private dropBasket() {
    this.basket.items = [];
    this.setBasket(this.basket).subscribe(res => {
      this.basketUpdateSource.next();
    });
  }
}
