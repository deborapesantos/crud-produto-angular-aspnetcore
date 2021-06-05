import { HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginDataService } from './login.data.service';
import { LoginResponse, UserLogin } from './user-login.model';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isError: boolean = false;

  loginResponse: LoginResponse = {
    success: false,
    error:''
  }

  public user: UserLogin = {
    Password: '',
    Username: ''
  };
  
  constructor(private LoginDataService: LoginDataService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit() { }

  public login() {
    
    this.LoginDataService.login(this.user)
      .then(x => 
        x.subscribe((data: HttpResponse<LoginResponse>) => {
          this.loginResponse = data.body;
          if (this.loginResponse.success)
            this.goToDashboard();
          else
          this.isError = true;
        })
    )
      .catch(x => console.log(x))

  }

  public goToDashboard() {
    this.router.navigate(['produto'], { relativeTo: this.route });
  }

}


