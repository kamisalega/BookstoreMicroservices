import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogComponent } from './catalog.component';
import {BrowserModule} from "@angular/platform-browser";
import {SharedModule} from "../shared/shared.module";
import {CatalogService} from "./catalog.service";



@NgModule({
  declarations: [CatalogComponent],
  imports: [
    BrowserModule,
    SharedModule,
    CommonModule
  ],
  providers: [CatalogService]
})
export class CatalogModule { }
