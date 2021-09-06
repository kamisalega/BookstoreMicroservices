import {Component, OnInit} from '@angular/core';
import {ConfigurationService} from "../../services/configuration.service";
import {SecurityService} from "../../services/security.service";
import {Subscription} from "rxjs";
import {SignalrService} from "../../services/signalr.service";

@Component({
  selector: 'bs-identity',
  templateUrl: './identity.component.html',
  styleUrls: ['./identity.component.scss']
})
export class IdentityComponent implements OnInit {
  authenticated: boolean = false;
  private subscription: Subscription;
  public userName: string = '';
  private isLoggedIn: boolean = false;

  constructor(private service: SecurityService, private signalrService: SignalrService) {
  }

  ngOnInit() {
    this.subscription = this.service.authenticationChallenge$.subscribe(res => {
        this.authenticated = res;
        this.userName = this.service.UserData.name;
      });

    if (window.location.hash) {
      this.service.AuthorizedCallback();
    }

    console.log('identity component, checking authorized' + this.service.IsAuthorized);
    this.authenticated = this.service.IsAuthorized;

    if (this.authenticated) {
      if (this.service.UserData)
        this.userName = this.service.UserData.name;
    }

    // this.service.isLoggedIn().then(loggedIn => {
    //   this.isLoggedIn = loggedIn;
    // })
  }

  login() {
    this.service.authorize()
  }

  logoutClicked(event: any) {
    event.preventDefault();
    console.log('Logout clicked');
    this.logout();

  }

  logout() {
     // this.signalrService.stop();
    this.service.logoff();
  }
}
