import { HttpResponse } from '@angular/common/http';
import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { APPSETTINGS } from '../../../config/global-propertys';
import { FileImageUploadComponent } from '../../../shared/file-image-upload/file-image-upload.component';
import { FileImageUploadModel } from '../../../shared/file-image-upload/file-image-upload.model';
import { Produto } from '../produto.model';
import { ProdutoDataService } from './../produto.data.service';


@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html',
  styleUrls: ['./produto-form.component.css']
})
export class ProdutoFormComponent implements OnInit {

  @ViewChild(FileImageUploadComponent, { static: false }) child: FileImageUploadComponent;


  afterSave: boolean = false;
  setIsError: boolean = false;
  isUpdate: boolean = false;
  produto: Produto = {
    Nome: "",
    PathImagem: "",
    ProdutoId: 0,
    ValorVenda: 0
  };

  imgUploasOptions: FileImageUploadModel = {
    formatsAllowed: ["image/png", "image/jpeg"],
    maxSize: 100000,//97.66KB
    style: {
      styleBackGround:""
    }
   
  };


  constructor(private ProdutoDataService: ProdutoDataService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {

      if (params) {
        if (Number(params.get("produtoId")) != 0) {
          this.produto.Nome = params.get("nome");
          this.produto.PathImagem = params.get("pathImagem");
          this.produto.ProdutoId = Number(params.get("produtoId"));
          this.produto.ValorVenda = Number(params.get("valorVenda"));
          this.isUpdate = true;
        }
      }
    });
  }

  save() {

    if (this.isUpdate)
      this.update();
    else
      this.createNew();

  }

  public createNew() {
    this.ProdutoDataService.CreateProduto(this.produto)
      .then(x =>
        x.subscribe((data: HttpResponse<any>) => {
          this.alerts(data);           
        }))
      .catch(x => {
        alert("Ocorreu um erro ao salvar informações!");
      })
  }

  public update() {

    this.ProdutoDataService.UpdateProduto(this.produto)
      .then(x =>
        x.subscribe((data: HttpResponse<any>) => {
          this.alerts(data);
        }))
      .catch(x => {
        alert("Ocorreu um erro ao salvar informações!");
      })
  }

  public alerts(data) {
    if (data.body) {
      alert("Salvo com sucesso!");
      this.router.navigate(['produto']);
    }
  }

  getImageData($event: FileList) {

    let fileToUpload = $event.item(0);
    if (fileToUpload) {


      let req = new XMLHttpRequest();
      const formData: FormData = new FormData();

      formData.append("file", fileToUpload);
      req.open("POST", APPSETTINGS.getBaseUrl() + '/api/Produtos/UploadImageProduto');
      req.onload = (e) => {
        if (req.response) {
          this.produto.PathImagem = req.response.replace('"', '');

          this.produto.PathImagem = this.produto.PathImagem.replace('"', '');
          this.child.success = true;
          this.child.isloading = false;
        }
      };
      req.onerror = (e) => {
        this.child.isloading = false;
        this.child.objError.isError = true;
        this.child.objError.mensagem = "Houve algum problema ao tentar fazer o upload da imagem, tente novamente.";
      }
      req.send(formData);

    }

   }
}
