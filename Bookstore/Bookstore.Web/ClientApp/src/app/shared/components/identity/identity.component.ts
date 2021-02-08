import { Component, OnInit } from '@angular/core';
import {ConfigurationService} from "../../services/configuration.service";

@Component({
  selector: 'bs-identity',
  templateUrl: './identity.component.html',
  styleUrls: ['./identity.component.scss']
})
export class IdentityComponent implements OnInit {

  constructor(private service: ConfigurationService) { }

  ngOnInit() {
    if(this.service.isReady){
      console.log('udało się');
    }
  }

}
