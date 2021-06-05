import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProdutoDataService } from './produto.data.service';
import { Produto } from './produto.model';

@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  listaProduto: Produto[];

  constructor(private ProdutoDataService: ProdutoDataService,
     private router: Router,
     private route: ActivatedRoute) { }

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.ProdutoDataService.getAllProduto()
      .then(x =>
        x.subscribe((data: HttpResponse<Produto[]>) => {
          this.listaProduto = data.body;
        })) 
  }

  public createNew() {
    var model = {
      Nome: "Produto teste",
      ValorVenda: 50.0,
      PathImagem: "/dd/2.jpg"
    };

    this.ProdutoDataService.CreateProduto(model)
      .then(x =>
        x.subscribe((data: HttpResponse<any>) => {
          console.log(data.body);
        })) 
  }

  public update() {
    var model = {
      ProdutoId: 1,
      Nome: "Produto teste update",
      ValorVenda: 150.0,
      PathImagem: "/dd/1.jpg"
    };

    this.ProdutoDataService.UpdateProduto(model)
      .then(x =>
        x.subscribe((data: HttpResponse<any>) => {
          console.log(data.body);
        }))
  }

  public delete(model) {
    if (window.confirm('Tem certeza que deseja deletar este item?')) {
      this.ProdutoDataService.DeleteProduto(model.produtoId)
        .then(x =>
          x.subscribe((data: HttpResponse<any>) => {
            this.getAll()
          }))
    }

    
  }

  openForm() {
     this.router.navigate(['produto-form']);   
  }

 

}
