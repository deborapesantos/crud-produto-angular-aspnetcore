import { Injectable } from '@angular/core';
import { BaseRequestService } from './../../config/base-request.service';
import { APPSETTINGS } from './../../config/global-propertys';
import { UserLogin } from './user-login.model';


@Injectable({
  providedIn: 'root'
})
export class LoginDataService {

  constructor(private BaseRequestService: BaseRequestService) { }

  async login(model:UserLogin) {
    return await this.BaseRequestService.openExternRequest('POST', APPSETTINGS.getBaseAuthUrl(), model);
  }
}
