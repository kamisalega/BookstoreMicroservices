import {Component, OnInit} from '@angular/core';
import {OrdersService} from "../orders.service";
import {BasketService} from "../../basket/basket.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {Router} from "@angular/router";
import {IOrder} from "../../shared/models/order.model";
import {catchError} from "rxjs/operators";
import {Observable} from "rxjs";
import {ErrorObservable} from "rxjs-compat/observable/ErrorObservable";

@Component({
  selector: 'bs-orders-new',
  templateUrl: './orders-new.component.html',
  styleUrls: ['./orders-new.component.scss']
})
export class OrdersNewComponent implements OnInit {

  errorReceived: boolean;
  order: IOrder;
  isOrderProcessing: boolean;
  newOrderForm: FormGroup;

  constructor(private orderService: OrdersService,
              private basketService: BasketService,
              fb: FormBuilder,
              private router: Router) {
    this.order = orderService.mapOrderAndIdentityInfoNewOrder();
    this.newOrderForm = fb.group(
      {
        'firstName': [this.order.firstName, Validators.required],
        'lastName': [this.order.lastName, Validators.required],
        'street': [this.order.address.street, Validators.required],
        'city': [this.order.address.city, Validators.required],
        'state': [this.order.address.state, Validators.required],
        'country': [this.order.address.country, Validators.required],
        'cardNumber': [this.order.cardNumber, Validators.required],
        'cardHolderName': [this.order.cardHolderName, Validators.required],
        'expirationDate': [this.order.expiration, Validators.required],
        'securityCode': [this.order.cardSecurityNumber, Validators.required],
      }
    )
  }

  ngOnInit() {
  }

  submitForm(value: any) {
    this.order.address.street = this.newOrderForm.controls['street'].value;
    this.order.address.city = this.newOrderForm.controls['city'].value;
    this.order.address.state = this.newOrderForm.controls['state'].value;
    this.order.address.country = this.newOrderForm.controls['country'].value;
    this.order.cardNumber = this.newOrderForm.controls['cardNumber'].value;
    this.order.cardTypeId = 1;
    this.order.cardHolderName = this.newOrderForm.controls['cardHolderName'].value;
    this.order.cardExpiration = new Date(20 + this.newOrderForm.controls['expirationDate'].value.split('/')[1],
      this.newOrderForm.controls['expirationDate'].value.split('/')[0]);
    this.order.cardSecurityNumber = this.newOrderForm.controls['securityCode'].value;
    let basketCheckout = this.basketService.mapBasketInfoCheckout(this.order);

    this.basketService.setBasketCheckout(basketCheckout)
      .pipe(catchError((errMessage) => {
        this.errorReceived = true;
        this.isOrderProcessing = false;
        return ErrorObservable.create('error')
      }))
      .subscribe(res => {
        this.router.navigate(['orders']);
      });
    this.errorReceived = false;
    this.isOrderProcessing = true;
  }

}
