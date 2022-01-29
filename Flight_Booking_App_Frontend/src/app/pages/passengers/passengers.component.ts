import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoggedService } from 'src/app/services/logged.service';
import { PassengerService } from 'src/app/services/passenger.service';

@Component({
  selector: 'app-passengers',
  templateUrl: './passengers.component.html',
  styleUrls: ['./passengers.component.scss']
})
export class PassengersComponent implements OnInit {
  public logged:boolean = false;
  public notLogged:boolean = true;
  public passengers:any[] = [];
  public PassengerForm!:FormGroup;
  public userid:number=0;
  public defaultDate:Date = new Date();
  public text:string = "Add Passenger";
  constructor(private formBuilder:FormBuilder, private loggedService:LoggedService, private router: Router, private passengerService:PassengerService) { }

  ngOnInit(): void {
    this.logged = this.loggedService.getIsLogged();
    this.notLogged = this.loggedService.getIsNotLogged();

    this.id();

    this.PassengerForm = this.formBuilder.group({
      firstName : ['', [Validators.required]],
      lastName : ['', [Validators.required]],
      dateOfBirth : [this.defaultDate],
      nationality : [''],
      travelDocument : [''],
      travelDocumentNumber : [''],
      travelDocumentExpirationDate : [this.defaultDate],
      userId : []
    });

    // console.log(this.PassengerForm);
  }

  goToHome(){
    this.loggedService.setLogged();
    this.router.navigateByUrl('/dashboard');
  }

  addPassenger(){
    console.log(this.PassengerForm);

    if(this.PassengerForm.valid){
      this.PassengerForm.value.userId = this.userid;
      this.passengerService.doAddPassenger(this.PassengerForm.value).subscribe((response:any)=>{
        console.log(this.PassengerForm.value);
        this.router.navigateByUrl('/passengers');
        // console.log(response);
      })
    }
  }

  id(){
    this.passengerService.findId().subscribe((response:any)=>{
      // this.bookingForm.value.userId = response;
      // console.log("response", response);
      var id = parseInt(response);
      this.userid = id;
      // return id;
    })
  }

}
