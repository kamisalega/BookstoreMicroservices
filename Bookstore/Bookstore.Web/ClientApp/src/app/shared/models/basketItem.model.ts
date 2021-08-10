import {IBook} from "./book.module";

export interface IBasketItem {
  basketLineId: string;
  bookId: string;
  basketId: string;
  price: number;
  bookAmount: number;
  book: IBook;
}
