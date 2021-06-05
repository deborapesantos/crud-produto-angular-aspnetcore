import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { FileImageUploadModel } from './file-image-upload.model';

@Component({
  selector: 'app-file-image-upload',
  templateUrl: './file-image-upload.component.html',
  styleUrls: ['./file-image-upload.component.scss']
})
export class FileImageUploadComponent implements OnInit {

    @Output() changeImgData: EventEmitter<any> = new EventEmitter();
    @Input() model;
    @Input() success: boolean;
    @Input() isloading: boolean;

    @Input() options: FileImageUploadModel;
    fileData: File = null;
    previewUrl: any = null;
    fileUploadProgress: string = null;
    uploadedFilePath: string = null;
    displayImg: string = null;
    

    objError= {
        isError: false,
        mensagem:''
    }

    constructor() { }
    ngOnInit() {
        this.success = false;
        this.isloading = false;
    }


    fileProgress(fileInput: any) {
        this.success = false;
        this.objError.isError = false;

        this.isloading = true;

        let permitido = false;
        this.fileData = <File>fileInput.target.files[0];
    
        if (this.options.formatsAllowed.length > 0) {
            this.options.formatsAllowed.forEach(x => {
                if (this.fileData.type == x) {
                    permitido = true;
                } 
            });
        }

        if (!permitido) {
            this.objError.isError = true;
            this.isloading = false;
            this.objError.mensagem = "Arquivo selecionado não é permitido, por favor selecione uma imagem e tente novamente.";
            return;
        } else {
            this.objError.isError = false;
            this.objError.mensagem = "";
        }


        if (this.fileData.size > this.options.maxSize) {
            this.objError.isError = true;
            this.isloading = false;
            this.objError.mensagem = "O tamanho do arquivo excede o esperado de 200px de largura por 64px de altura.";
            return;
        } else {
            this.objError.isError = false;
            this.objError.mensagem = "";
        }

        this.changeImgData.emit(fileInput.target.files);
       
        this.preview();
    }

    preview() {
        // Show preview 
        var mimeType = this.fileData.type;
        if (mimeType.match(/image\/*/) == null) {
            return;
        }

        var reader = new FileReader();
        reader.readAsDataURL(this.fileData);
        reader.onload = (_event) => {
            this.previewUrl = reader.result;
        }
        
    }
   
}
