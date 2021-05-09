import {IOrderItem} from './orderItem.model';

export interface IOrderDetail {
  orderNumber: string;
  status: string;
  description: string;
  street: string;
  date: Date;
  city: number;
  state: string;
  zipcode: string;
  country: number;
  total: number;
  orderItems: IOrderItem[];
}
