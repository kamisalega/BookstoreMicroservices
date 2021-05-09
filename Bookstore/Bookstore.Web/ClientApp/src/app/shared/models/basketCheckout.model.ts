export interface IBasketCheckout {
  city: number;
  street: string;
  state: string;
  country: number;
  zipcode: string;
  cardNumber: string;
  cardExpiration: Date;
  expiration: string;
  cardSecurityNumber: string;
  cardHolderName: string;
  cardTypeId: number;
  buyer: string;
  orderNumber: string;
  total: number;
}
