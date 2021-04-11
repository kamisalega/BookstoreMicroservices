import {ModuleWithProviders, NgModule} from '@angular/core';
import { BasketComponent } from './basket.component';
import {SharedModule} from "../shared/shared.module";
import {BasketService} from "./basket.service";



@NgModule({
  declarations: [BasketComponent],
  imports: [
    SharedModule
  ],
  providers: [BasketService],
})
export class BasketModule {
  static forRoot(): ModuleWithProviders{
    return {
      ngModule: BasketModule,
      providers: [
        BasketService
      ]
    }
  }
}
