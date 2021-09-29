import {RouterModule, Routes} from "@angular/router";
import {CatalogComponent} from "./catalog/catalog.component";
import {BasketComponent} from "./basket/basket.component";
import {OrdersComponent} from "./orders/orders.component";
import {OrdersDetailComponent} from "./orders/orders-detail/orders-detail.component";
import {OrdersNewComponent} from "./orders/orders-new/orders-new.component";

export const routes: Routes = [
  {path: '', redirectTo: 'catalog', pathMatch: 'full'},
  {path: 'catalog', component: CatalogComponent},
  {path: 'basket', component: BasketComponent},
  {path: 'basket', component: BasketComponent},
  { path: 'orders', component: OrdersComponent },
  { path: 'orders/:id', component: OrdersDetailComponent },
  { path: 'order', component: OrdersNewComponent },
]
export const routing = RouterModule.forRoot(routes, {relativeLinkResolution: 'legacy'});
