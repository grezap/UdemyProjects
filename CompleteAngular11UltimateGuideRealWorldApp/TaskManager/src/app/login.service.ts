import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginViewModel } from './login-view-model';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  //baseApi:string = "http://localhost:13629/api";
  baseApi:string = "http://localhost:61384/api";
  
  currentUserName:string = "";
  
  constructor(private httpClient:HttpClient) { }

  public Login(loginViewModel:LoginViewModel):Observable<any>{
    return this.httpClient.post<any>(this.baseApi + "/authenticate",loginViewModel, {responseType: "json"})
    .pipe(map(user => {
      if(user){
        this.currentUserName = user.userName;
        sessionStorage.currentUser = JSON.stringify(user);
      }
      return user;
     }));
  }

public LogOut(){
  sessionStorage.removeItem("currentUser");
  this.currentUserName = "";
}

}
