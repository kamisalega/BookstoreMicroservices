import {Component, OnInit, ViewContainerRef} from '@angular/core';
import {ToastrService} from "ngx-toastr";
import {Title} from "@angular/platform-browser";
import {Subscription} from "rxjs";

@Component({
  selector: 'bs-app',
  styleUrls: ['./app.component.scss'],
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  Authenticated: boolean = false;
  subscription: Subscription;

  constructor(
    private titleService: Title,
    private toastr: ToastrService,
    vcr: ViewContainerRef
  ) {
    // TODO: Set Taster Root (Overlay) container
    //this.toastr.setRootViewContainerRef(vcr);
  }

  ngOnInit(): void {
  }

  public setTitle(newTitle: string) {
    this.titleService.setTitle('eShopOnContainers');
  }
}
