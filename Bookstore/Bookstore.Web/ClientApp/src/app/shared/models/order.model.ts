import {IOrderBook} from "./orderBook.model";
import {IAddress} from "./address.model";

export  interface IOrder {
  email: string;
  basketId: string;
  firstName: string;
  lastName: string;
  cardNumber: number;
  cardExpiration: Date;
  expiration: string;
  cardSecurityNumber: string;
  cardHolderName: string;
  cardTypeId: number;
  buyer: string;
  orderNumber: string;
  total: number;
  address: IAddress;
  orderBooks: IOrderBook[];
}
