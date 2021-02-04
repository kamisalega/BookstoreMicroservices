import {RouterModule, Routes} from "@angular/router";

export const routes: Routes = [
  {path: '', redirectTo: 'catalog', pathMatch: 'full'}
]
export const routing = RouterModule.forRoot(routes);
