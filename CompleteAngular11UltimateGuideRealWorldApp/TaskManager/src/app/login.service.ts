import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginViewModel } from './login-view-model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  currentUserName:string = "";
  constructor(private httpClient:HttpClient) { }

  public Login(loginViewModel:LoginViewModel):Observable<any>{
    return this.httpClient.post<any>("/authenticate",loginViewModel, {responseType: "json"})
    .pipe(map(user => {
      if(user){
        this.currentUserName = user.UserName;
      }
      return user;
     }));
  }

public LogOut(){
  this.currentUserName = "";
}

}
