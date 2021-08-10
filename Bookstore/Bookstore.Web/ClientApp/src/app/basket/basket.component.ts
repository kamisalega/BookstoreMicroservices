import { Component, OnInit } from '@angular/core';
import {BasketService} from "./basket.service";
import {Router} from "@angular/router";
import {BasketWrapperService} from "../shared/services/basket.wrapper.service";
import {IBasket} from "../shared/models/basket.model";
import {IBasketItem} from "../shared/models/basketItem.model";
import {Observable} from "rxjs";

@Component({
  selector: 'bs-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss']
})
export class BasketComponent implements OnInit {
  errorMessages:any;
  basket: IBasket;
  totalPrice: number = 0;

  constructor(
    private basketService: BasketService,
    private router: Router,
    private basketWrapperService: BasketWrapperService
  ) { }

  ngOnInit() {
      this.basketService.getBasket().subscribe(basket => {
        console.log(basket);
        this.basket = basket;
        this.calculateTotalPrice();
      },
      errorMessages => console.log(errorMessages)
      );
  }

  deleteItem(id: String) {
    this.basket.basketLines = this.basket.basketLines.filter(item => item.basketLineId !== id);
    this.calculateTotalPrice();

    this.basketService.setBasketLines(this.basket).subscribe(x =>
      {
        this.basketService.updateQuantity();
        console.log('basket updated: ' + x)
      }
    );
  }

  itemQuantityChanged(item: IBasketItem, quantity: number) {
    item.bookAmount = quantity > 0 ? quantity : 1;
    this.calculateTotalPrice();
    this.basketService.setBasketLines(this.basket).subscribe(x => console.log('basket updated: ' + x));
  }

  update(event: any): Observable<boolean> {
    let setBasketObservable = this.basketService.setBasketLines(this.basket);
    setBasketObservable
      .subscribe(
        x => {
          this.errorMessages = [];
          console.log('basket updated: ' + x);
        },
        errMessage => this.errorMessages = errMessage.messages);
    return setBasketObservable;
  }

  checkOut(event: any) {
    this.update(event)
      .subscribe(
        x => {
          this.errorMessages = [];
          this.basketWrapperService.basket = this.basket;
          this.router.navigate(['order']);
        });
  }


  private calculateTotalPrice() {
    this.totalPrice = 0;
    this.basket.basketLines.forEach( item => {
      this.totalPrice += (item.price * item.bookAmount);
    });
  }

}
