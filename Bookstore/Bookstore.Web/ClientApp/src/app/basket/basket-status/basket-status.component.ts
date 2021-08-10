import {Component, OnInit} from '@angular/core';
import {BasketService} from "../basket.service";
import {BasketWrapperService} from "../../shared/services/basket.wrapper.service";
import {SecurityService} from "../../shared/services/security.service";
import {ConfigurationService} from "../../shared/services/configuration.service";
import {Subscription} from "rxjs";
import {StorageService} from "../../shared/services/storage.service";

@Component({
  selector: 'bs-basket-status',
  templateUrl: './basket-status.component.html',
  styleUrls: ['./basket-status.component.scss']
})
export class BasketStatusComponent implements OnInit {
  private basketItemAddedSubscription: Subscription;
  private basketUpdateSubscription: Subscription;
  private authSubscription: Subscription;

  public badge: number = 0;
  private storage: StorageService;

  constructor(private basketService: BasketService,
              private basketWrapperService: BasketWrapperService,
              private authService: SecurityService,
              private configurationService: ConfigurationService,
              private storageService: StorageService
  ) {
    this.storage = storageService;
  }

  ngOnInit() {
    this.basketService
    this.basketItemAddedSubscription = this.basketWrapperService.addItemToBasket$.subscribe(item => {
      if (this.storage.retrieve('basketId')) {
        item.basketId = this.storage.retrieve('basketId');
        this.addItem(item);
      } else {
        this.basketService.setBasketId(item).subscribe(resBasket => {
          item.basketId = resBasket.basketId;
          this.addItem(item);
        });
      }
    });

    this.basketUpdateSubscription = this.basketService.basketUpdate$.subscribe(res => {
      this.basketService.getBasket().subscribe(basket => {
        this.badge = basket ? basket.bookAmount : 0;
      });
    });

    // Subscribe to login and logout observable
    this.authSubscription = this.authService.authenticationChallenge$.subscribe(res => {
      this.basketService.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.bookAmount;
      });
    });

    // Init:
    if (this.configurationService.isReady) {
      this.basketService.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.bookAmount;
      });
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.basketService.getBasketByUserId().subscribe(res => {
          if (!this.storage.retrieve('basketId')) {
            this.badge = 0;
          } else {
            this.basketService.getBasket().subscribe(basket => {
              if (basket != null)
                this.badge = basket.bookAmount;
            });
          }
        });
      });
    }
  }

  private addItem(item) {
    this.basketService.addItemToBasket(item).subscribe(res => {
      console.log(res);
      this.basketService.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.bookAmount;
      });
    });
  }

}
