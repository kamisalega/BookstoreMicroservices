import {RouterModule, Routes} from "@angular/router";
import {CatalogComponent} from "./catalog/catalog.component";
import {BasketComponent} from "./basket/basket.component";

export const routes: Routes = [
  {path: '', redirectTo: 'catalog', pathMatch: 'full'},
  {path: 'catalog', component: CatalogComponent},
  {path: 'basket', component: BasketComponent},
]
export const routing = RouterModule.forRoot(routes, {relativeLinkResolution: 'legacy'});
