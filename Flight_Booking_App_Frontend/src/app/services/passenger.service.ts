import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PrivateService } from './private.service';

@Injectable({
  providedIn: 'root'
})
export class PassengerService {
  private baseUrl: string = environment.baseUrl;
  public username!:string | null;
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'json'
    }),
  };
  
  constructor(private http: HttpClient, private privateService:PrivateService) { }

  findId(){
    this.getUsername();
    
    return this.http.get(
      this.baseUrl + 'api/UserAuthentication/getCurrentUserId/' + this.username,
      this.privateHttpHeaders
    );
  }

  getUsername(){
    var currentUsername = this.privateService.getUsername();
    this.username = currentUsername;
    console.log(this.username);
  }

  doAddPassenger(data: any){
    return this.http.post(
      this.baseUrl + 'api/Passenger/AddPassenger',
      data,
      this.privateHttpHeaders
    )
  }
}
