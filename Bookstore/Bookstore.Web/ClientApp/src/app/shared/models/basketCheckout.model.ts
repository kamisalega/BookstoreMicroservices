import {IAddress} from "./address.model";

export interface IBasketCheckout {

  basketId: string;
  email: string;
  lastName: string;
  firstName: string;
  address: IAddress;
  cardNumber: number;
  cardExpiration: Date;
  expiration: string;
  cardSecurityNumber: string;
  cardHolderName: string;
  cardTypeId: number;
  buyer: string;
  orderNumber: string;
  basketTotal: number;
}
