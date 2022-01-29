import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from "@angular/router";
import { DashboardComponent } from '../dashboard/dashboard.component';
import { LoggedService } from 'src/app/services/logged.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public text:string = "Login";
  public isDisabled:boolean = false;

  public loginForm!:FormGroup;

  public logged:boolean = false;
  public notLogged:boolean = true;

  constructor(private formBuilder:FormBuilder, private authService:AuthService, private router: Router, private loggedService:LoggedService) { }

  ngOnInit(): void {
    //this.text = "Login";
    this.loginForm = this.formBuilder.group(
      {
        email : ['aaa@a.com', [Validators.required]],
        password : ['Andreea2001@', [Validators.required]]
      }
    );
  }

  login(){
    // console.log("Hello");

    if(this.loginForm.valid){
      this.authService.login(this.loginForm.value)
      .subscribe((response:any)=>{
        // console.log(response);
        // this.dashboardComponent.isNotLogged = false;
        // this.dashboardComponent.isLogged = true;
        localStorage.setItem('currentUser', this.loginForm.value.email);
        this.loggedService.setLogged();
        this.notLogged = this.loggedService.getIsNotLogged();
        this.logged = this.loggedService.getIsLogged();
        console.log("Not ", this.notLogged);
        console.log("log ", this.logged);
        this.router.navigateByUrl('/dashboard');
      })
    }
  }
}
