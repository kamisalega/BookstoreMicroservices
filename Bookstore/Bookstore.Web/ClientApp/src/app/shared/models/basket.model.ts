import {IBasketItem} from "./basketItem.model";

export interface IBasket {
  basketLines: IBasketItem[];
  userId: string;
  basketId: string;
  bookId: string;
  bookAmount: number,
  couponId: string,
}
