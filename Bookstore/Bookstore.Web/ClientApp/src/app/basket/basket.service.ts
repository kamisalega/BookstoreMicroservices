import {Injectable} from '@angular/core';
import {IBasket} from "../shared/models/basket.model";
import {Subject} from "rxjs";
import {DataService} from "../shared/services/data.service";
import {BasketWrapperService} from "../shared/services/basket.wrapper.service";
import {Router} from "@angular/router";
import {ConfigurationService} from "../shared/services/configuration.service";
import {StorageService} from "../shared/services/storage.service";
import {SecurityService} from "../shared/services/security.service";

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private basketUrl: string = '';
  private purchaseUrl: string = '';
  basket: IBasket = {
    buyerId: '',
    items: []
  };
  private basketDropedSource = new Subject();
  basketDroped$ = this.basketDropedSource.asObservable();

  constructor(
    private service: DataService,
    private authService: SecurityService,
    private basketEvents: BasketWrapperService,
    private router: Router,
    private configurationService: ConfigurationService,
    private storageService: StorageService
  ) {
    this.basket.items = [];

    // if (this.authService.IsAuthorized) {
    //   if (this.authService.UserData) {
    //     this.basket.buyerId = this.authService.UserData.sub;
    //     if (this.configurationService.isReady) {
    //       this.basketUrl = this.configurationService.serverSettings.purchaseUrl;
    //       this.purchaseUrl = this.configurationService.serverSettings.purchaseUrl;
    //       this.loadData();
    //     }
    //     else {
    //       this.configurationService.settingsLoaded$.subscribe(x => {
    //         this.basketUrl = this.configurationService.serverSettings.purchaseUrl;
    //         this.purchaseUrl = this.configurationService.serverSettings.purchaseUrl;
    //         this.loadData();
    //       });
    //     }
    //   }
    // }
  }
}
