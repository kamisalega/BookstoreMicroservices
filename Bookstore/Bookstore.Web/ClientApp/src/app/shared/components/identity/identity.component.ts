import { Component, OnInit } from '@angular/core';
import {ConfigurationService} from "../../services/configuration.service";
import {SignalrService} from "../../services/signalr.service";
import {SecurityService} from "../../services/security.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'bs-identity',
  templateUrl: './identity.component.html',
  styleUrls: ['./identity.component.scss']
})
export class IdentityComponent implements OnInit {

  authenticated: boolean = false;
  private subscription: Subscription;
  private userName: string = '';

  constructor(private service: SecurityService, private signalrService: SignalrService) {

  }

  ngOnInit() {
    this.subscription = this.service.authenticationChallenge$.subscribe(res => {
      this.authenticated = res;
      this.userName = this.service.UserData.email;
    });

    if (window.location.hash) {
      this.service.AuthorizedCallback();
    }

    console.log('identity component, checking authorized ' + this.service.IsAuthorized);
    this.authenticated = this.service.IsAuthorized;

    if (this.authenticated) {
      if (this.service.UserData)
        this.userName = this.service.UserData.email;
    }
  }

  logoutClicked(event: any) {
    event.preventDefault();
    console.log('Logout clicked');
    this.logout();
  }

  login() {
    this.service.Authorize();
  }

  logout() {
    this.signalrService.stop();
    this.service.Logoff();
  }
}
