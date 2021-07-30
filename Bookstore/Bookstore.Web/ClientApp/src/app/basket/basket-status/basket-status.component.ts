import {Component, OnInit} from '@angular/core';
import {BasketService} from "../basket.service";
import {BasketWrapperService} from "../../shared/services/basket.wrapper.service";
import {SecurityService} from "../../shared/services/security.service";
import {ConfigurationService} from "../../shared/services/configuration.service";
import {Subscription} from "rxjs";

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

  constructor(private basketService: BasketService,
              private basketWrapperService: BasketWrapperService,
              private authService: SecurityService,
              private configurationService: ConfigurationService) {

  }

  ngOnInit() {
    this.basketItemAddedSubscription = this.basketWrapperService.addItemToBasket$.subscribe(item => {
      this.basketService.addItemToBasket(item).subscribe(res => {
        this.basketService.getBasket().subscribe(basket => {
          if (basket != null)
            this.badge = basket.items.length;
        });
      });
    });

    this.basketUpdateSubscription = this.basketService.basketUpdate$.subscribe(res => {
      this.basketService.getBasket().subscribe(basket => {
        this.badge = basket ? basket.items.length : 0;
      });
    });

    // Subscribe to login and logout observable
    this.authSubscription = this.authService.authenticationChallenge$.subscribe(res => {
      this.basketService.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.items.length;
      });
    });

    // Init:
    if (this.configurationService.isReady) {
      this.basketService.getBasket().subscribe(basket => {
        if (basket != null)
          this.badge = basket.items.length;
      });
    } else {
      this.configurationService.settingsLoaded$.subscribe(x => {
        this.basketService.getBasket().subscribe(basket => {
          if (basket != null)
            this.badge = basket.items.length;
        });
      });
    }
  }

}
