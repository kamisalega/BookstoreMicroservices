import {Injectable} from '@angular/core';
import {SecurityService} from "./security.service";
import {ConfigurationService} from "./configuration.service";
import {ToastrService} from "ngx-toastr";
import {HubConnection} from "@microsoft/signalr";

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  private _hubConnection: HubConnection;

  constructor(
    private securityService: SecurityService,
    private configurationService: ConfigurationService,
    private toastr: ToastrService
  ) {
    if (this.configurationService.isReady) {
      // this.SignalHubUrl = this.configurationService.serverSettings.signalrHubUrl;
    }
  }

  stop() {
    this._hubConnection.stop();
  }
}
