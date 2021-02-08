import {ModuleWithProviders, NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {HttpClientJsonpModule, HttpClientModule} from "@angular/common/http";
import {HeaderComponent} from './components/header/header.component';
import {PageNotFoundComponent} from './components/page-not-found/page-not-found.component';
import {PagerComponent} from './components/pager/pager.component';
import {IdentityComponent} from './components/identity/identity.component';
import {ConfigurationService} from "./services/configuration.service";
import {StorageService} from "./services/storage.service";
import {DataService} from "./services/data.service";


@NgModule({
  declarations: [
    HeaderComponent,
    PageNotFoundComponent,
    PagerComponent,
    IdentityComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    HttpClientModule,
    HttpClientJsonpModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    IdentityComponent,
    PagerComponent
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        ConfigurationService,
        StorageService,
        DataService
      ]
    }
  }
}
