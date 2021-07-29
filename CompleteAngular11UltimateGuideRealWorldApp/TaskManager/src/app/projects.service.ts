import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from './project';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProjectsService {

  //baseApi:string = "http://localhost:13629/api";
  baseApi:string = "http://localhost:61384/api";

  constructor(private httpClient:HttpClient) { 

  }

  getAllProjects(): Observable<Project[]>{
    // var currentUser = {token:""};
    // var headers = new HttpHeaders();
    // headers = headers.set("Authorization","Bearer");
    // if (sessionStorage.currentUser != null) {
    //   currentUser = JSON.parse(sessionStorage.currentUser);
    //   headers = headers.set("Authorization","Bearer " + currentUser.token);
    // }

    return this.httpClient.get<Project[]>(this.baseApi+"/projects", {responseType: "json"})
    .pipe(map(
      (data:Project[])=>{
        for (let i = 0; i < data.length; i++) {
          data[i].teamSize = data[i].teamSize * 100;
        }
        return data;
      }
    ));
  }

  insertProject(newProject:Project):Observable<Project>{
    return this.httpClient.post<Project>(this.baseApi+"/projects",newProject, {responseType: "json"});
  }

  updateProject(existingproject:Project):Observable<Project>{
    return this.httpClient.put<Project>(this.baseApi+"/projects",existingproject, {responseType: "json"});
  };

  deleteProject(ProjectID:number):Observable<string>{
    return this.httpClient.delete<string>(this.baseApi + "/projects?ProjectID="+ProjectID)
  };

  searchProjects(searchBy:string,searchText:string):Observable<Project[]>{
    return this.httpClient.get<Project[]>(this.baseApi + "/projects/search/"+searchBy+"/"+searchText, {responseType: "json"});
  };

}
