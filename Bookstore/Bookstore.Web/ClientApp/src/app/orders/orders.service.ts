import {Injectable} from '@angular/core';
import {IOrder} from "../shared/models/order.model";
import {DataService} from "../shared/services/data.service";
import {BasketWrapperService} from "../shared/services/basket.wrapper.service";
import {SecurityService} from "../shared/services/security.service";
import {ConfigurationService} from "../shared/services/configuration.service";
import {IOrderBook} from "../shared/models/orderBook.model";
import {IAddress} from "../shared/models/address.model";

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private ordersUrl: string = '';
  private basketUrl: string = '';

  constructor(private service: DataService,
              private basketService: BasketWrapperService,
              private identityService: SecurityService,
              private configurationService: ConfigurationService) {
    if (this.configurationService.isReady)
    {
      this.ordersUrl = this.configurationService.serverSettings.orderUrl;
      this.basketUrl = this.configurationService.serverSettings.basketUrl;
    }
    else {
      this.configurationService.settingsLoaded$.subscribe(x => this.ordersUrl = this.configurationService.serverSettings.orderUrl);
      this.configurationService.settingsLoaded$.subscribe(x => this.basketUrl = this.configurationService.serverSettings.basketUrl);
    }}

   mapOrderAndIdentityInfoNewOrder(): IOrder {
    let order = <IOrder>{};
    let address = <IAddress>{};
    let basket = this.basketService.basket;
    let identityInfo = this.identityService.UserData;

    console.log(basket);
    console.log(identityInfo);

    // Identity data mapping:
    order.firstName = identityInfo.given_name;
    order.lastName = identityInfo.family_name;
    order.email = identityInfo.email;
    address.street = identityInfo.address.street_address;
    address.city = identityInfo.address.locality;
    address.country = identityInfo.address.country;
    address.state = identityInfo.address.state;
    address.zipcode = identityInfo.address.postal_code;
    order.address = address;
    order.cardExpiration = identityInfo.credit_card.card_expiration;
    order.cardNumber = identityInfo.credit_card.card_number;
    order.cardSecurityNumber = identityInfo.credit_card.card_security_number;
    order.cardTypeId = identityInfo.credit_card.card_type;
    order.cardHolderName = identityInfo.credit_card.card_holder;
    order.total = 0;
    order.expiration = identityInfo.credit_card.card_expiration;
    order.basketId = basket.basketId;


    // basket data mapping:
    order.orderBooks = new Array<IOrderBook>();
    basket.basketLines.forEach(x => {
      let book: IOrderBook = <IOrderBook>{};
      book.imageUrl = x.book.imageUrl;
      book.bookId = x.bookId;
      book.bookName = `${x.book.author.name} - ${x.book.title}`;
      book.unitPrice = x.price;
      book.units = x.bookAmount;
      order.total += (book.unitPrice * book.units);
      order.orderBooks.push(book);
    });

    order.buyer = basket.userId;

    return order;
  }
}
