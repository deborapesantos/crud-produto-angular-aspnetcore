import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';

import { LoginComponent } from './pages/login/login.component';
import { LoginDataService } from './pages/login/login.data.service';

import { ProdutoComponent } from './pages/produto/produto.component';
import { ProdutoDataService } from './pages/produto/produto.data.service';
import { ProdutoFormComponent } from './pages/produto/produto-form/produto-form.component';

import { FileImageUploadComponent } from './shared/file-image-upload/file-image-upload.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    ProdutoComponent,
    ProdutoFormComponent,
    FileImageUploadComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LoginComponent, pathMatch: 'full' },
      { path: 'produto', component: ProdutoComponent },
      { path: 'produto-form', component: ProdutoFormComponent },
    ])
  ],
  schemas: [
    CUSTOM_ELEMENTS_SCHEMA,
    NO_ERRORS_SCHEMA
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
