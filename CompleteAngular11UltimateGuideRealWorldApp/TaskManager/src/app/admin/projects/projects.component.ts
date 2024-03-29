import { Component, OnInit } from '@angular/core';
import { ProjectsService } from '../../projects.service';
import { Project } from 'src/app/project';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent implements OnInit {

  projects:Project[]=[];
  newProject:Project = new Project();
  editProject:Project = new Project();
  editIndex: number = 0;
  deleteProject:Project = new Project();
  deleteIndex: number = 0;
  searchBy:string = "ProjectName";
  searchText:string = "";

  constructor(private projectsService:ProjectsService) { }

  ngOnInit(): void {
    this.projectsService.getAllProjects().subscribe(
      (response:Project[])=>{
        this.projects = response;
      }
    );
  }

  onSaveClick(){
    this.projectsService.insertProject(this.newProject).subscribe(
      //Handle Data
      (response) => {
        var p: Project = new Project();
        p.projectID = response.projectID;
        p.projectName = response.projectName;
        p.dateOfStart = response.dateOfStart;
        p.teamSize = response.teamSize;
        this.projects.push(p);

        this.newProject.projectID = 0;
        this.newProject.projectName = "";
        this.newProject.dateOfStart = "";
        this.newProject.teamSize = 0;
      },
      //Handle Error
      (error)=>{
        console.log(error);
      }
    );
  }

  onEditClick(event:any, index:number){
    this.editProject.projectID = this.projects[index].projectID;
    this.editProject.projectName = this.projects[index].projectName;
    this.editProject.dateOfStart = this.projects[index].dateOfStart;
    this.editProject.teamSize = this.projects[index].teamSize;
    this.editIndex = index;
  }

  onUpdateClick(){
    this.projectsService.updateProject(this.editProject).subscribe(
      (response:Project)=>{
        var p:Project = new Project();
        p.projectID = response.projectID;
        p.projectName = response.projectName;
        p.dateOfStart = response.dateOfStart;
        p.teamSize = response.teamSize;
        this.projects[this.editIndex] = p;
        this.editProject.projectID = 0;
        this.editProject.projectName = "";
        this.editProject.dateOfStart = "";
        this.editProject.teamSize = 0;
      },
      (error)=>{console.log(error);}
    );
  }

  onDeleteClick(event:any, index:number){
    this.deleteIndex = index;
    this.deleteProject.projectID = this.projects[index].projectID;
    this.deleteProject.projectName = this.projects[index].projectName;
    this.deleteProject.dateOfStart = this.projects[index].dateOfStart;
    this.deleteProject.teamSize = this.projects[index].teamSize;
  }

  onDeleteConfirmClick(){
    this.projectsService.deleteProject(this.deleteProject.projectID).subscribe(
      (response)=>{
        this.projects.splice(this.deleteIndex, 1);
        this.deleteProject.projectID = 0;
        this.deleteProject.projectName = "";
        this.deleteProject.dateOfStart = "";
        this.deleteProject.teamSize = 0;
      },
      (error)=>{console.log(error);}
    );

  }

  onSearchClick(){
    this.projectsService.searchProjects(this.searchBy,this.searchText).subscribe(
      (response:Project[])=>{
        this.projects = response;
      },
      (error)=>{console.log(error);},
    );
  }

}
