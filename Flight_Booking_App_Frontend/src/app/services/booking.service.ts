import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ChangeDetectorRef, Injectable, NgZone } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PrivateService } from './private.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private baseUrl: string = environment.baseUrl;
  public username!:string | null;
  public userid:number=1;
  public idNew:number=0;
  public hello:boolean=false;
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'json'
    }),
  };

  constructor(private http: HttpClient, private privateService:PrivateService, private ngZone: NgZone) { 
  }

  findId(){
    this.getUsername();
    console.log("Booking", this.username);
    return this.http.get(
      this.baseUrl + 'api/UserAuthentication/getCurrentUserId/' + this.username,
      this.privateHttpHeaders
    );
  }

  doBooking(data: any) {
    return this.http.post(
      this.baseUrl + 'api/Booking/AddBooking',
      data,
      this.privateHttpHeaders
    );
  }

  id(){
    this.findId().subscribe((response:any)=>{
      // this.ngZone.run( () => {
      //   this.userid = response;
      //   // this.hello = true;
      // });

      // this.bookingForm.value.userId = response;
      // console.log("response", response);
      // var idU = parseInt(response);
      // return idU;
      // id = response;
      // console.log(response);
      // this.userid = response;

      // this.setUser(response);
      
      // console.log("hello", this.userid);
      return response;
    })
  }

  setUser(data:any){
    this.userid = data;
  }

  getAllBookings(){
    this.id();
    // console.log(this.hello);
    // console.log("USER2", this.userid);

    return this.http.get(
      this.baseUrl + 'api/Booking/GetAllBookings/' + this.userid,
      this.privateHttpHeaders
    )
}

  getUsername(){
    var currentUsername = this.privateService.getUsername();
    this.username = currentUsername;
    console.log(this.username);
  }
}
