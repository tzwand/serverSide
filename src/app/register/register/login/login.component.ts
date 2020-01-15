import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService, AlertService } from '../../_services';
// @Component({
//   selector: 'app-login',
//   templateUrl: './login.component.html',
//   styleUrls: ['./login.component.css']
// })
@Component({templateUrl: 'login.component.html'})
export class LoginComponent implements OnInit {
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
        username: ['', Validators.required,Validators.email],
        password: ['', [Validators.required, Validators.pattern('[a-zA-Z0-9]*'),Validators.minLength(6)]]
  });
  this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';

        this.route.params.
    subscribe((paramsFromUrl: Params) => {
       this.type= paramsFromUrl.type;
    });
  }
    loginForm: FormGroup;
    loading = false;
    submitted = false;
    returnUrl: string;
    type: number;
    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authenticationService: AuthenticationService,
        private alertService: AlertService) {}
        // reset login status
onSubmit() {
      this.submitted = true;
      // stop here if form is invalid
      if (this.loginForm.invalid) {
          return;
      }

      this.loading = true;
      this.authenticationService.login(this.f.username.value, this.f.password.value)
          .pipe(first())
          .subscribe(
              data => {
                  this.router.navigate(['donor/'+this.f.username.value+'/'+this.f.password.value])
                //   this.router.navigate([this.returnUrl]);
              },
              error => {
                  this.alertService.error(error);
                  this.loading = false;
              });
  }
get f() {return this.loginForm.controls;}
}
  
  