import { LoginComponent } from "./app/register/register/login/login.component";
import { LearnerScreenComponent } from "./app/components/learner/learner-screen/learner-screen.component";
import { DonorScreenComponent } from "./app/components/donor/donor-screen/donor-screen.component";
import { Component } from "@angular/core";
import { ProfileComponent } from "./app/register/register/profile/profile.component";
import { RegisterComponent } from "./app/register/register/register";
import { HomeComponent } from "./app/register/register/home";
// import { AuthGuard } from "./app/register/_guards";
import { TimeComponent } from "./app/components/donor/time/time.component";
import { GroupComponent } from "./app/components/donor/group/group.component";
import { PaymentsComponent } from "./app/components/donor/payments/payments.component";
import { FinalScreenComponent } from "./app/components/donor/final-screen/final-screen.component";
import { PurposeComponent } from "./app/components/donor/purpose/purpose.component";
import { AppComponent } from "./app/app.component";
import { NewLoginComponent } from "./app/components/login/new-login/new-login.component";
import { NewRegisterComponent } from "./app/components/login/new-register/new-register.component";
import { LearnerDashboardComponent } from './app/components/learner/learner-dashboard/learner-dashboard.component';
import { ResetPasswordComponent } from './app/components/login/reset-password/reset-password.component';

export const appNavigations = [

   { path: '',  redirectTo: "/", pathMatch:'full'},
  // { path: '', component: AppComponent, canActivate: [AuthGuard] },
  { path: 'login/:type', component: NewLoginComponent },
  { path: 'resetPassword', component: ResetPasswordComponent },
  { path: 'register/:type', component: NewRegisterComponent },
  { path: 'learner', component: LearnerScreenComponent,
    // children: [
    //   {
    //     path: 'learner/:email/:password/profile/',
    //     component: ProfileComponent,
    //   }

    // ]
  },
  { path: 'learner/dashboard', component: LearnerDashboardComponent },

  {
    path: 'donor', component: DonorScreenComponent,
    children: [
      { path: 'time', component: TimeComponent },
      { path: 'group', component: GroupComponent },
      { path: 'payments', component: PaymentsComponent },
      { path: 'finalScreen', component: FinalScreenComponent },
      { path: 'purpose', component: PurposeComponent }]
  },
  // { path: 'profile', component: ProfileComponent },
  { path: 'app', component: AppComponent },
  // otherwise redirect to home
  { path: '**', redirectTo: '' }

  //     { path: '**', component: LoginComponent} ,
  //  { path: '',  redirectTo: "app", pathMatch:'full'}
]
