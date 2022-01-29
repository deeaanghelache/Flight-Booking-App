import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoggedService } from 'src/app/services/logged.service';

@Component({
  selector: 'app-congratulations',
  templateUrl: './congratulations.component.html',
  styleUrls: ['./congratulations.component.scss']
})
export class CongratulationsComponent implements OnInit {

  public logged:boolean = true;
  public notLogged:boolean = false;

  constructor(private loggedService:LoggedService, private router: Router) { }

  ngOnInit(): void {
    this.logged = this.loggedService.getIsLogged();
    this.notLogged = this.loggedService.getIsNotLogged();
  }

  goToHome(){
    this.loggedService.setLogged();
    this.router.navigateByUrl('/dashboard');
  }

}
