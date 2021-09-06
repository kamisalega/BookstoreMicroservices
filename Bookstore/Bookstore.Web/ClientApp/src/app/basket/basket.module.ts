import {ModuleWithProviders, NgModule} from '@angular/core';
import { BasketComponent } from './basket.component';
import {SharedModule} from "../shared/shared.module";
import {BasketService} from "./basket.service";
import { BasketStatusComponent } from './basket-status/basket-status.component';



@NgModule({
    declarations: [BasketComponent, BasketStatusComponent],
    imports: [
        SharedModule
    ],
    providers: [BasketService],
    exports: [
        BasketStatusComponent
    ]
})
export class BasketModule {
  static forRoot(): ModuleWithProviders<BasketModule>{
    return {
      ngModule: BasketModule,
      providers: [
        BasketService
      ]
    }
  }
}
