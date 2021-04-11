import {Injectable} from '@angular/core';
import {Subject} from "rxjs";
import {Guid} from "../../../../guid";
import {ICatalogItem} from "../models/catalogItem.model";
import {IBasketItem} from "../models/basketItem.model";

@Injectable({
  providedIn: 'root'
})
export class BasketWrapperService {

  constructor() {
  }

  // observable that is fired when a product is added to the cart
  private addItemToBasketSource = new Subject<IBasketItem>();
  addItemToBasket$ = this.addItemToBasketSource.asObservable();

  private orderCreatedSource = new Subject();
  orderCreated$ = this.orderCreatedSource.asObservable();

  addItemToBasket(item: ICatalogItem) {
    // if (this.identityService.IsAuthorized) {
    let basket: IBasketItem = {
      pictureUrl: item.imageUrl,
      productId: item.id,
      productName: item.categoryName,
      quantity: 1,
      unitPrice: item.price,
      id: Guid.newGuid(),
      oldUnitPrice: 0
    };
    //
    //   this.addItemToBasketSource.next(basket);
    // } else {
    //   // this.identityService.Authorize();
    // }
  }

  orderCreated() {
    this.orderCreatedSource.next();

  }
}

