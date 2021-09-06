import {Component, OnInit, ViewContainerRef} from '@angular/core';
import {ToastrService} from "ngx-toastr";
import {Title} from "@angular/platform-browser";
import {Subscription} from "rxjs";
import {ConfigurationService} from "./shared/services/configuration.service";
import {SecurityService} from "./shared/services/security.service";
import {Router} from "@angular/router";

@Component({
  selector: 'bs-app',
  styleUrls: ['./app.component.scss'],
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  Authenticated: boolean = false;
  subscription: Subscription;

  constructor(
    public router: Router,
    private titleService: Title,
    private securityService: SecurityService,
    private toastr: ToastrService,
    vcr: ViewContainerRef,
    private configurationService: ConfigurationService,
  ) {
    // TODO: Set Taster Root (Overlay) container
    //this.toastr.setRootViewContainerRef(vcr);
    this.Authenticated = this.securityService.IsAuthorized;
  }

  ngOnInit(): void {
    console.log('app on init');
    this.subscription = this.securityService.authenticationChallenge$.subscribe(res => this.Authenticated = res);
    this.configurationService.load();
  }

  public setTitle(newTitle: string) {
    this.titleService.setTitle('eShopOnContainers');
  }
}
