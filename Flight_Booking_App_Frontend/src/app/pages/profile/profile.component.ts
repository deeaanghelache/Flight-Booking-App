import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoggedService } from 'src/app/services/logged.service';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public username:string | null ='';
  public logged:boolean = true;
  public notLogged:boolean = false;

  constructor(private privateService:PrivateService, private loggedService:LoggedService, private router: Router) { }

  ngOnInit(): void {
    this.getUsername();
  }

  getUsername(){
    var currentUsername = this.privateService.getUsername();
    this.username = currentUsername;
    console.log(this.username);
  }

  goToHome(){
    this.loggedService.setLogged();
    this.router.navigateByUrl('/dashboard');
  }

}
