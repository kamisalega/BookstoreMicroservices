import {IBook} from "./book.model";

export interface IBasketItem {
  basketLineId: string;
  bookId: string;
  basketId: string;
  price: number;
  bookAmount: number;
  book: IBook;

}
