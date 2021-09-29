import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {StorageService} from "./storage.service";
import {Observable, Subject} from "rxjs";
import {ActivatedRoute, Router} from "@angular/router";
import {ConfigurationService} from "./configuration.service";
import {User, UserManager} from "oidc-client";

@Injectable({
  providedIn: 'root'
})
export class SecurityService {

  private actionUrl: string;
  private headers: HttpHeaders;
  private storage: StorageService;
  private authenticationSource = new Subject<boolean>();
  authenticationChallenge$ = this.authenticationSource.asObservable();
  private authorityUrl = '';
  public IsAuthorized: boolean;
  private userManager: UserManager;
  UserData: any;
  private loginChangedSubject = new Subject<boolean>();
  private user: User;

  constructor(private _http: HttpClient,
              private _router: Router,
              private route: ActivatedRoute,
              private _configurationService: ConfigurationService,
              private _storageService: StorageService) {
    this.headers = new HttpHeaders();
    this.headers.append('Content-Type', 'application/json');
    this.headers.append('Accept', 'application/json');
    this.storage = _storageService;

    this._configurationService.settingsLoaded$.subscribe(x => {
      this.authorityUrl = this._configurationService.serverSettings.identityUrl;
      this.storage.store('identityUrl', this.authorityUrl);
    });

    if (this.storage.retrieve('IsAuthorized') !== '') {
      this.IsAuthorized = this.storage.retrieve('IsAuthorized');
      this.authenticationSource.next(true);
      this.UserData = this.storage.retrieve('userData');
    }
  }

  public authorize() {
    this.resetAuthorizationData();

    const stsSettings = {
      authority: this.authorityUrl + '/connect/authorize',
      client_id: "bookstorem2m",
      client_secret: "eac7008f-1b35-4325-ac8d-4a71932e6088",
      redirect_uri: `${location.origin}/`,
      scope: 'openid profile credit_card email address bookstore.fullaccess',
      response_type: 'id_token token',
      nonce: 'N' + Math.random() + '' + Date.now(),
      state: Date.now() + '' + Math.random()
    }

    let url =
      stsSettings.authority + '?' +
      'response_type=' + encodeURI(stsSettings.response_type) + '&' +
      'client_id=' + encodeURI(stsSettings.client_id) + '&' +
      'redirect_uri=' + encodeURI(stsSettings.redirect_uri) + '&' +
      'scope=' + encodeURI(stsSettings.scope) + '&' +
      'nonce=' + encodeURI(stsSettings.nonce) + '&' +
      'state=' + encodeURI(stsSettings.state);

    this.storage.store('authStateControl', stsSettings.state);
    this.storage.store('authNonce', stsSettings.nonce);

    window.location.href = url;
  }

  public AuthorizedCallback() {
    this.resetAuthorizationData();

    let hash = window.location.hash.substr(1);

    let result: any = hash.split('&').reduce(function (result: any, item: string) {
      let parts = item.split('=');
      result[parts[0]] = parts[1];
      return result;
    }, {});

    console.log(result)

    let token = '';
    let id_token = '';
    let authResponseIsValid = false;

    if (!result.error) {
      if (result.state !== this.storage.retrieve('authStateControl')) {
        console.log('AuthorizedCallback incorrect state');
      } else {
        token = result.access_token;
        id_token = result.id_token;
        let dataIdToken: any = this.getDataFromToken(id_token);
        // validate nonce
        if (dataIdToken.nonce !== this.storage.retrieve('authNonce')) {
          console.log('AuthorizedCallback incorrect nonce');
        } else {
          this.storage.store('authNonce', '');
          this.storage.store('authStateControl', '');

          authResponseIsValid = true;
          console.log('AuthorizedCallback state and nonce validated, returning access token');
        }
      }
    }
    if (authResponseIsValid) {
      this.setAuthorizationData(token, id_token);
    }
  }

  public resetAuthorizationData() {
    this.storage.store('authorizationData', '');
    this.storage.store('authorizationDataIdToken', '');

    this.IsAuthorized = false;
    this.storage.store('IsAuthorized', false);
  }

  private getDataFromToken(token: any) {
    let data = {};

    if (typeof token !== 'undefined') {
      console.log(token.split('.'))
      let encoded = token.split('.')[1];
       data = JSON.parse(this.urlBase64Decode(encoded));
    }
    return data;
  }

  private urlBase64Decode(str: string) {
    let output = str.replace('-', '+').replace('_', '/');

    switch (output.length % 4) {
      case 0:
        break;
      case 2:
        output += '==';
        break;
      case 3:
        output += '=';
        break;
      default:
        throw 'Ilegal base64url string!'
    }
    return window.atob(output);
  }

  private setAuthorizationData(token: string, id_token: string) {

    if (this.storage.retrieve('authorizationData') !== '') {
      this.storage.store('authorizationData', '');
    }

    this.storage.store('authorizationData', token);
    this.storage.store('authorizationDataIdToken', id_token);
    this.IsAuthorized = true;
    this.storage.store('IsAuthorized', true);

    this.getUserData()
      .subscribe(data => {
          this.UserData = data;
          this.storage.store('userData', data);
          // emit observable
          this.authenticationSource.next(true);
          window.location.href = location.origin;
        },
        error => this.handleError(error),
        () => {
          console.log(this.UserData);
        });

  }

  private getUserData = (): Observable<string[]> => {

    if (this.authorityUrl === '' || this.authorityUrl === undefined) {
      this.authorityUrl = this.storage.retrieve('identityUrl');
    }

    const options = this.setHeaders();

    return this._http.get<string[]>(`${this.authorityUrl}/connect/userinfo`, options)
      .pipe<string[]>((info: any) => info);
  }

  private setHeaders() {
    const httpOptions = {
      headers: new HttpHeaders()
    };

    httpOptions.headers = httpOptions.headers.set('Content-Type', 'application/json');
    httpOptions.headers = httpOptions.headers.set('Accept', 'application/json');

    const token = this.getToken();

    if (token !== '') {
      httpOptions.headers = httpOptions.headers.set('Authorization', `Bearer ${token}`);
    }

    return httpOptions;
  }

  public getToken() : any{
    return this.storage.retrieve('authorizationData');
  }

  private handleError(error: any) {

    console.log(error);
    if (error.status == 403) {
      this._router.navigate(['/Forbidden']);
    }
    else if (error.status == 401) {
      this._router.navigate(['/Unauthorized']);
    }

  }

  logoff() {
    let authorizationUrl = this.authorityUrl + '/connect/endsession';
    let id_token_hint = this.storage.retrieve('authorizationDataIdToken');
    let post_logout_redirect_uri = location.origin + '/';

    let url =
      authorizationUrl + '?' +
      'id_token_hint=' + encodeURI(id_token_hint) + '&' +
      'post_logout_redirect_uri=' + encodeURI(post_logout_redirect_uri);

    this.resetAuthorizationData();

    this.authenticationSource.next(false);
    window.location.href = url;

  }
}
