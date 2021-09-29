import {Injectable} from '@angular/core';
import {IBasket} from "../shared/models/basket.model";
import {Observable, Subject, throwError} from "rxjs";
import {DataService} from "../shared/services/data.service";
import {BasketWrapperService} from "../shared/services/basket.wrapper.service";
import {Router} from "@angular/router";
import {ConfigurationService} from "../shared/services/configuration.service";
import {StorageService} from "../shared/services/storage.service";
import {SecurityService} from "../shared/services/security.service";
import {catchError, tap} from "rxjs/operators";
import {HttpErrorResponse} from "@angular/common/http";
import {IOrder} from "../shared/models/order.model";
import {IBasketCheckout} from "../shared/models/basketCheckout.model";

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private basketUrl: string = '';
  private purchaseUrl: string = '';
  basket: IBasket = {
    userId: '',
    basketId: '',
    bookId: '',
    bookAmount: 0,
    couponId: '',
    basketLines: []
  };
  //observable that is fired when item is removed from basket
  private basketUpdateSource = new Subject();
  basketUpdate$ = this.basketUpdateSource.asObservable();
  private storage: StorageService;

  constructor(
    private service: DataService,
    private authService: SecurityService,
    private basketWrapperService: BasketWrapperService,
    private router: Router,
    private configurationService: ConfigurationService,
    private storageService: StorageService
  ) {
    this.basket.basketLines = [];
    this.storage = storageService;

    if (this.authService.IsAuthorized) {
      if (this.authService.UserData) {
        this.basket.userId = this.authService.UserData.sub;
        if (this.storage.retrieve('basketId') !== '') {
          this.basket.basketId = this.storage.retrieve('basketId');
        }
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
      this.deleteBasket(x)
    });
  }

  addItemToBasket(item): Observable<boolean> {
    return this.setBasketLines(item);
  }

  getBasket(): Observable<IBasket> {
    this.validBasketUrl();
    let url = this.basketUrl + '/api/baskets/' + this.basket.basketId;

    return this.service.get(url).pipe<IBasket>(tap((response: any) => {
      if (response.status === 204) {
        return null;
      }
      return response;
    }));
  }

  handleError(err: HttpErrorResponse) {
    let errorMessage = '';
    if (err.error instanceof ErrorEvent) {

      //a client-side or network error occured. Handle it accordingly.
      errorMessage = `An error occured: ${err.error.message}`;

    } else {
      //The back-end returned an unsuccessful response code.
      errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
    }
    return throwError(errorMessage);
  }

  public setBasketLines(basketLine): Observable<boolean> {
    let url = this.basketUrl + '/api/baskets/' + basketLine.basketId + '/basketlines'

    return this.service.post(url, basketLine).pipe<boolean>(tap((response: any) => {
      return true;
    }));
  }

  public updateBasketLine(basketLineForUpdate): Observable<boolean> {
    let url = this.basketUrl + '/api/baskets/' + basketLineForUpdate.basketId + '/basketlines/' + basketLineForUpdate.basketLineId;
    return this.service.put(url, basketLineForUpdate).pipe<boolean>(tap((response: any) => {
      return true;
    }));
  }

  public deleteBasket(basketLineForDelete): Observable<boolean> {
    this.basket.basketLines = this.basket.basketLines.filter(item => item.basketLineId !== basketLineForDelete.basketLineId);
    let url = this.basketUrl + '/api/baskets/' + basketLineForDelete.basketId + '/basketlines/' + basketLineForDelete.basketLineId;
    return this.service.delete(url).pipe<boolean>(tap((response: any) => {
      return true;
    }));
  }

  private loadData() {
    this.getBasket().subscribe(basket => {
      if (basket != null) {
        this.basket.basketLines = basket.basketLines;
      }
    })
  }

  setBasketId(basket): Observable<IBasket> {

    let url = this.basketUrl + '/api/baskets/'

    // this.basket.items.push(basketItem);
    this.basket.bookId = basket.bookId;

    return this.service.post(url, this.basket).pipe<IBasket>(
      tap(
        (response: any) => {
          this.storage.store('basketId', response.basketId)
          return response;
        }));
  }

  updateQuantity() {
    this.basketUpdateSource.next();
  }

  getBasketByUserId(): Observable<IBasket> {
    this.validBasketUrl();

    let url = this.basketUrl + '/api/baskets/' + this.basket.userId + '/userbasket';

    return this.service.get(url).pipe<IBasket>(tap((response: any) => {
      if (response.status === 204) {
        return null;
      }
      this.storage.store('basketId', response.basketId)
      this.basket.basketId = response.basketId;
      return response;
    }));
  }

  private validBasketUrl() {
    if (!this.basketUrl) {
      this.basketUrl = this.storage.retrieve('basketUrl');
    }
  }

  updateBasket(basket): Observable<boolean> {
    let url = this.basketUrl + '/api/baskets/'

    this.basket = basket;

    return this.service.put(url, this.basket).pipe<boolean>(
      tap(
        (response: any) => {
          this.storage.store('basketId', response.basketId)
          return true;
        }));
  }

    mapBasketInfoCheckout(order): IBasketCheckout {
    let basketCheckout = <IBasketCheckout>{};

    basketCheckout.firstName = order.firstName;
    basketCheckout.lastName = order.lastName;
    basketCheckout.email = order.email;
    basketCheckout.basketId = order.basketId;
    basketCheckout.address = order.address;
    basketCheckout.cardExpiration = order.cardExpiration;
    basketCheckout.cardNumber = order.cardNumber;
    basketCheckout.cardSecurityNumber = order.cardSecurityNumber;
    basketCheckout.cardTypeId = order.cardTypeId;
    basketCheckout.cardHolderName = order.cardHolderName;
    basketCheckout.basketTotal = 0;
    basketCheckout.expiration = order.expiration;
    basketCheckout.buyer = order.buyer;

    return basketCheckout;
  }


  setBasketCheckout(basketCheckout): Observable<boolean> {
    let url = this.basketUrl + '/api/baskets/checkout';
    return this.service.post(url, basketCheckout).pipe<boolean>
    (
      tap(
        (response: any) => true
      )
    );
  }
}
