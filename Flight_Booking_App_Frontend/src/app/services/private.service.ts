import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrivateService {

  private baseUrl:string=environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: 'Bearer ' + localStorage.getItem("token"),
    }),
  };

  constructor(private http:HttpClient) { }

  getAllUsers(){
    return this.http.get(this.baseUrl+'api/UserAuthentication/getAllUsers', this.privateHttpHeaders);
  }

  getCurrentUsername(){
    return this.http.get(this.baseUrl+'api/UserAuthentication/getCurrentUser', this.privateHttpHeaders);
  }

  getUsername(){
    var username = localStorage.getItem('currentUser');
    console.log(username);
    return username;
  } 

  getAllDestinations(){
    return this.http.get(this.baseUrl+'api/Flight/GetAllDestinations');
  }

  getAllDepartures(){
    return this.http.get(this.baseUrl+'api/Flight/GetAllDepartures');
  }
}
