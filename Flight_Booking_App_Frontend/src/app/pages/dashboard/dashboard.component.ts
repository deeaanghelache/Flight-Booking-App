import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { LoggedService } from 'src/app/services/logged.service';
import { PrivateService } from 'src/app/services/private.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  public users:any[] = [];
  public destinations:any[] = [];
  public departures:any[] = [];
  public nrOfPassengers:any[] = [1, 2, 3, 4, 5];
  public text:string = "Book your flight";
  public bookingForm!:FormGroup;
  public defaultDate:Date = new Date();
  // public username:string | null = this.privateService.getUsername();
  public userid:number=0;

  public logged:boolean = false;
  public notLogged:boolean = true;

  constructor(private bookingService:BookingService, private router: Router, private privateService:PrivateService, private loggedService:LoggedService, private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    // this.getAllUsers();
    // this.loggedService.setNotLogged();
    this.logged = this.loggedService.getIsLogged();
    this.notLogged = this.loggedService.getIsNotLogged();
    // console.log("Not ", this.notLogged);
    // console.log("log ", this.logged);

    // console.log("user id ", this.bookingService.findId());
    this.id();
    this.getAllDest();
    this.getAllDepts();

    this.bookingForm = this.formBuilder.group({
      departureAirport : ['', [Validators.required]],
      arrivalAirport : ['', [Validators.required]],
      numberOfPassengers : [],
      departureDate : [this.defaultDate],
      arrivalDate : [this.defaultDate],
      class : [''],
      onlyDirect : [''], 
      userId : [],
    });
  }

  id(){
    this.bookingService.findId().subscribe((response:any)=>{
      // this.bookingForm.value.userId = response;
      // console.log("response", response);
      var id = parseInt(response);
      this.userid = id;
      // return id;
    })
  }

  book(){
    // this.id();

    console.log(this.bookingForm);

    if(this.bookingForm.valid){
      this.bookingForm.value.userId = this.userid;
      console.log("userId", this.bookingForm.value.userId );
      this.bookingService.doBooking(this.bookingForm.value).subscribe((response:any)=>{
        console.log(this.bookingForm.value);
        this.router.navigateByUrl('/congratulations');
        // console.log(response);
      })
    }
  }

  // getAllUsers(){
  //   this.privateService.getAllUsers().subscribe((response:any)=>{
  //     this.users = response.allUsers;
  //   })
  // }

  getAllDest(){
    this.privateService.getAllDestinations().subscribe((response:any)=>{
      this.destinations = response;
      // console.log(this.destinations);
    })
  }

  getAllDepts(){
    this.privateService.getAllDepartures().subscribe((response:any)=>{
      this.departures = response;
      // console.log(this.departures);
    })
  }
}
