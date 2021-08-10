import {Injectable} from '@angular/core';
import {Subject} from "rxjs";
import {Guid} from "../../../../guid";
import {ICatalogItem} from "../models/catalogItem.model";
import {IBasketItem} from "../models/basketItem.model";
import {SecurityService} from "./security.service";
import {IBasket} from "../models/basket.model";
import {IBook} from "../models/book.module";

@Injectable({
  providedIn: 'root'
})
export class BasketWrapperService {
  public basket: IBasket;

  constructor(private identityService: SecurityService) {
  }

  // observable that is fired when a product is added to the cart
  private addItemToBasketSource = new Subject<IBasketItem>();
  addItemToBasket$ = this.addItemToBasketSource.asObservable();

  private orderCreatedSource = new Subject();
  orderCreated$ = this.orderCreatedSource.asObservable();

  addItemToBasket(item: ICatalogItem) {
    if (this.identityService.IsAuthorized) {

      let newBook: IBook = {
        bookId: item.id,
        title: item.title,
        imageUrl: item.imageUrl,
        date: item.date
      };

      let basket: IBasketItem = {
        book: newBook,
        bookId: item.id,
        basketId: item.basketId,
        bookAmount: 1,
        price: item.price,
        basketLineId: Guid.newGuid()
        // oldUnitPrice: 0
      };

      this.addItemToBasketSource.next(basket);
    } else {
      this.identityService.authorize();
    }
  }


  orderCreated() {
    this.orderCreatedSource.next();
  }
}

