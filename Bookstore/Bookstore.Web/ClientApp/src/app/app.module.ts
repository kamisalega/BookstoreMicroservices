import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppService } from './app.service';
import { AppComponent } from './app.component';
import {ToastrModule} from "ngx-toastr";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {routing} from "./app.routes";
import {SharedModule} from "./shared/shared.module";
import {CatalogModule} from "./catalog/catalog.module";
import {BasketModule} from "./basket/basket.module";
import {OrdersModule} from "./orders/orders.module";

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    routing,
    SharedModule.forRoot(),
    CatalogModule,
    BasketModule,
    OrdersModule
  ],
  providers: [AppService],
  bootstrap: [AppComponent]
})
export class AppModule { }
