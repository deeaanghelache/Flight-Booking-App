import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggedService {
  public isNotLogged:boolean = true;
  public isLogged:boolean = false;

  constructor() { }

  setLogged(){
    this.isNotLogged = false;
    this.isLogged = true;
  }

  setNotLogged(){
    this.isLogged = false;
    this.isNotLogged = true;
  }

  getIsLogged(){
    return this.isLogged;
  }

  getIsNotLogged(){
    return this.isNotLogged;
  }
}
