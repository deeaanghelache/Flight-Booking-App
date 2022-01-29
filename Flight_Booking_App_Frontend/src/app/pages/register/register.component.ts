import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm!:FormGroup;
  public text:string = 'Create Account';

  // cu formBuilder se creeaza un form group
  constructor(private formBuilder:FormBuilder, private authService:AuthService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group(
      {
        email : ['', [Validators.required, Validators.email]],
        password : ['', [Validators.required]],
        role : ['User'],
        confirmPassword : ['', [Validators.required]]
      }, { validators: this.checkPasswords }
    );
  }

  checkPasswords: ValidatorFn = (group: AbstractControl):  ValidationErrors | null => { 
    // ? nu da eroare daca parola e null
    let password = group.get('password')?.value;
    let confirmPassword = group.get('confirmPassword')?.value
    return password === confirmPassword ? null : { passwordsMismatched: true }
  }

  doRegister(){
    console.log(this.registerForm);

    if(this.registerForm.valid){
      this.authService.register(this.registerForm.value)
      .subscribe((response:any)=>{
        console.log(response);
      })
    }
  }
}
