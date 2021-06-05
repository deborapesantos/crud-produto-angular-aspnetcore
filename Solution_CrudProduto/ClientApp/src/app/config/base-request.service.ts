import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { APPSETTINGS } from './global-propertys';

@Injectable({
  providedIn: 'root'
})

export class BaseRequestService {
  baseUrl: string = APPSETTINGS.getBaseUrl();

  constructor(private _httpClient: HttpClient) { }

  openExternRequest(method: string, url: string, model: any = null) {
    var req = new HttpRequest(method, url, model, { reportProgress: false, responseType: "json" })
    return this._httpClient.request(req);
  }

  openRequest(method: string, url: string, model: any = null) {
    var req = new HttpRequest(method, this.baseUrl + url, model, { reportProgress: false, responseType: "json" })
    return this._httpClient.request(req);
  }

  openRequestArrayBuffer(method: string, url: string, model: any = null) {
    var req = new HttpRequest(method, this.baseUrl + url, model, { reportProgress: false, responseType: "arraybuffer" })
    return this._httpClient.request(req);
  }

  openRquestTentativa(method: string, url: string, model: any = null) {
    var req = new HttpRequest(method, url, model, { reportProgress: false, responseType: "json" })
    return this._httpClient.request(req);
  }
}


