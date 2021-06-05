import { Injectable } from '@angular/core';
import { BaseRequestService } from './../../config/base-request.service';

@Injectable({
  providedIn: 'root'
})
export class ProdutoDataService {

  constructor(private BaseRequestService: BaseRequestService) { }

  async getAllProduto() {
    return await this.BaseRequestService.openRequest('GET', '/api/Produtos/GetAllProdutos');
  }

  async getbyIdProduto(id) {
    return await this.BaseRequestService.openRequest('GET', '/api/Produtos/GetProdutoById?pId=' + id);
  }

  async CreateProduto(model) {
    return await this.BaseRequestService.openRequest('POST', '/api/Produtos/CreateProduto', model);
  }

  async UpdateProduto(model) {
    return await this.BaseRequestService.openRequest('POST', '/api/Produtos/UpdateProduto', model);
  }

  async DeleteProduto(id) {
    return await this.BaseRequestService.openRequest('GET', '/api/Produtos/DeleteProdutoById?pId=' + id);
  }

}
