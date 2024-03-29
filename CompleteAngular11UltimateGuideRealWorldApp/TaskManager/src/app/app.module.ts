import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {JwtModule } from '@auth0/angular-jwt';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AdminModule } from './admin/admin.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { JwtInterceptorService } from './jwt-interceptor.service';
import { JwtUnAuthorizedInterceptorService } from './jwt-un-authorized-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AdminModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return ( sessionStorage.getItem("currentUser") 
                   ? JSON.parse(sessionStorage.getItem("currentUser") as string).token 
                   : null);
        }
      }
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptorService,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtUnAuthorizedInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
