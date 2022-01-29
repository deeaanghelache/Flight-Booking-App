import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookingService } from 'src/app/services/booking.service';
import { LoggedService } from 'src/app/services/logged.service';
import { PrivateService } from 'src/app/services/private.service';

@Component({
  selector: 'app-bookings',
  templateUrl: './bookings.component.html',
  styleUrls: ['./bookings.component.scss']
})
export class BookingsComponent implements OnInit {
  public logged:boolean = true;
  public username:string | null ='';
  public notLogged:boolean = false;
  public bookings:any[] = [];

  constructor(private privateService: PrivateService, private loggedService:LoggedService, private router: Router, private bookingService: BookingService) { }

  ngOnInit(): void {
    this.getAllBookingsForCurrentUser();
    this.getUsername();
  }

  goToHome(){
    this.loggedService.setLogged();
    this.router.navigateByUrl('/dashboard');
  }

  getAllBookingsForCurrentUser(){
    this.bookingService.getAllBookings().subscribe((response:any)=>{
      this.bookings = response;
      console.log(this.bookings);
    })
  }

  getUsername(){
    var currentUsername = this.privateService.getUsername();
    this.username = currentUsername;
    console.log(this.username);
  }
}
