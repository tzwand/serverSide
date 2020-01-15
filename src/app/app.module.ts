import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { appNavigations } from '../routelist';
import { LearnerScreenComponent } from './components/learner/learner-screen/learner-screen.component';
import { DonorScreenComponent } from './components/donor/donor-screen/donor-screen.component';
import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import {CalendarModule} from 'primeng/calendar';
import { FullCalendarModule } from '@fullcalendar/angular';
// import { LoginComponent } from './register/register/login/login.component';
// import { ProfileComponent } from './register/register/profile/profile.component';
// import { HomeComponent } from './register/register/home/home.component';
// import { RegisterComponent } from './register/register/register';
// import { AuthGuard } from './register/_guards';
// import { AlertService,AuthenticationService,UserService } from './register/_services';
// import { AlertComponent } from './register/_directives';
// import { JwtInterceptor,ErrorInterceptor,fakeBackendProvider} from './register/_helpers';
import { TimeComponent } from './components/donor/time/time.component';
import { PaymentsComponent } from './components/donor/payments/payments.component';
import { GroupComponent } from './components/donor/group/group.component';
import { PurposeComponent } from './components/donor/purpose/purpose.component';
import { NewRegisterComponent } from "./components/login/new-register/new-register.component";
// used to create fake backend
import { NbThemeModule, NbCardModule,NbInputModule, NbMenuService, NbTabsetModule, NbRouteTabsetModule, NbUserModule, NbMenuModule, NbListModule, NbButtonModule, NbCheckboxModule, NbRadioModule, NbSelectModule, NbDatepickerModule } from '@nebular/theme';
import { NbSidebarModule, NbLayoutModule, NbSidebarService, NbStepperModule, NbContextMenuModule } from '@nebular/theme';
import { NewLoginComponent } from './components/login/new-login/new-login.component';
import { NbMenuInternalService } from '@nebular/theme/components/menu/menu.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { ToolbarModule } from 'primeng/toolbar';
import { FileUploadModule } from 'primeng/fileupload';
import { FinalScreenComponent } from './components/donor/final-screen/final-screen.component';
import { BookComponent } from './components/donor/book/book/book.component';
import { UserService } from './services/user/user.service';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { CalenderComponent } from './components/misc/calender/calender.component';
import { LearnerDashboardComponent } from './components/learner/learner-dashboard/learner-dashboard.component';
import { StepCardComponent } from './components/donor/extra/step-card/step-card.component';
import {MatRadioModule} from '@angular/material/radio';
import { ResetPasswordComponent } from './components/login/reset-password/reset-password.component';

@NgModule({
  declarations: [
    AppComponent,
    // LoginComponent,
    LearnerScreenComponent,
    DonorScreenComponent,
    // ProfileComponent,
    AppComponent,
    // AlertComponent,
    // HomeComponent,
    // LoginComponent,
    // RegisterComponent,
    TimeComponent,
    PaymentsComponent,
    GroupComponent,
    PurposeComponent,
    NewRegisterComponent,
    FinalScreenComponent,
    NewLoginComponent, BookComponent, CalenderComponent, LearnerDashboardComponent, StepCardComponent, ResetPasswordComponent

  ],
  imports: [
    BrowserModule, FormsModule, ReactiveFormsModule, NbLayoutModule//,AppRoutingModule
    , RouterModule.forRoot(appNavigations, { enableTracing: true }), NbThemeModule.forRoot()
    , HttpClientModule, RouterModule, // RouterModule.forRoot(routes, { useHash: true }), if this is your app.module
    // tslint:disable-next-line:max-line-length
    NbLayoutModule, NbCardModule, NbStepperModule, NbRouteTabsetModule,NbCheckboxModule,NbRadioModule,NbSelectModule, NbDatepickerModule.forRoot(),NbDatepickerModule,
    NbSidebarModule, NbContextMenuModule, NbTabsetModule,NbInputModule ,NbButtonModule, BrowserAnimationsModule, ButtonModule, ToolbarModule,
    Ng2SmartTableModule, NbUserModule, NbMenuModule.forRoot(), NbMenuModule, FileUploadModule, NbListModule, ScrollPanelModule,FullCalendarModule,CalendarModule,MatRadioModule
  ],
  providers: [
    // AuthGuard,
    // AlertService,
    // AuthenticationService,
    NbSidebarService,
    UserService, NbMenuService, NbMenuInternalService,
    // { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    // { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },

    // provider used to create fake backend
    // fakeBackendProvider
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }




