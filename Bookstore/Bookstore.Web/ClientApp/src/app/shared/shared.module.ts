import {ModuleWithProviders, NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {RouterModule} from "@angular/router";
import {NgbModule} from "@ng-bootstrap/ng-bootstrap";
import {HttpClientJsonpModule, HttpClientModule} from "@angular/common/http";


// Services
import {ConfigurationService} from "./services/configuration.service";
import {StorageService} from "./services/storage.service";
import {DataService} from "./services/data.service";
import {BasketWrapperService} from "./services/basket.wrapper.service";

// Components:
import {HeaderComponent} from './components/header/header.component';
import {PageNotFoundComponent} from './components/page-not-found/page-not-found.component';
import {PagerComponent} from './components/pager/pager.component';
import {IdentityComponent} from './components/identity/identity.component';
import {SignalrService} from "./services/signalr.service";
import {SecurityService} from "./services/security.service";
import {UppercasePipe} from "./pipes/uppercase.pipe";


@NgModule({
  declarations: [
    HeaderComponent,
    PageNotFoundComponent,
    PagerComponent,
    IdentityComponent,
    UppercasePipe
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    // No need to export as these modules don't expose any components/directive etc'
    HttpClientModule,
    HttpClientJsonpModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NgbModule,
    // Providers, Components, directive, pipes
    IdentityComponent,
    PagerComponent,
    HeaderComponent,
    PageNotFoundComponent,
    UppercasePipe
  ]
})
export class SharedModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: SharedModule,
      providers: [
        DataService,
        BasketWrapperService,
        SecurityService,
        ConfigurationService,
        StorageService,
        SignalrService
      ]
    }
  }
}
