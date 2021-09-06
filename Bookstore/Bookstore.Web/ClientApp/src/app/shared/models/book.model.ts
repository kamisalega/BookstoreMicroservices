import {IAuthor} from "./author.model";

export interface IBook {
  bookId: string;
  title: string;
  date: string;
  imageUrl: string;
  price: number;
  author: IAuthor;
}
