import { Component, OnInit } from '@angular/core';
import { DashboardService } from 'src/app/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  Designation: string = "";
  Username: string = "";
  NoOfTeamMembers: number = 0;
  TotalCostOfAllProjects: number = 0;
  PendingTasks: number = 0;
  UpComingProjects: number = 0;
  ProjectCost: number = 0;
  CurrentExpenditure: number = 0;
  AvailableFunds: number = 0;

  Clients:string[]=[];
  Projects:string[]=[];
  Years:number[]=[];
  TeamMembersSummary:any=[];
  TeamMembers:any=[];

constructor(private dashboardService: DashboardService){

}

  ngOnInit(): void {
    this.Designation = "Team Leader";
    this.Username = "John Smith";
    this.NoOfTeamMembers = 67;
    this.TotalCostOfAllProjects = 240;
    this.PendingTasks = 15;
    this.UpComingProjects = 0.2;
    this.ProjectCost = 2113507;
    this.CurrentExpenditure = 96788;
    this.AvailableFunds = 52536;

    this.Clients = [
      "ABC Infotech Ltd.", "DEF Software Solutions", "GHI Industries"
    ];

    this.Projects = [
      "Project A","Project B","Project C","Project D"
   ];

    for (let index = 2019; index >= 2010; index--) {
      this.Years.push(index);      
    }

    this.TeamMembersSummary = this.dashboardService.getTeamMembersSummary();

    this.TeamMembers = [
      {Region: "East", Members: [
        { ID: 1, Name: "Ford", Status: "Available" },
        { ID: 2, Name: "Miller", Status: "Available" },
        { ID: 3, Name: "Jones", Status: "Busy" },
        { ID: 4, Name: "James", Status: "Busy" }
      ]},
      {Region: "West", Members: [
        { ID: 1, Name: "Anna", Status: "Available" },
        { ID: 2, Name: "Arun", Status: "Available" },
        { ID: 3, Name: "Varun", Status: "Busy" },
        { ID: 4, Name: "Jasmine", Status: "Busy" }
      ]},
      {Region: "South", Members: [
        { ID: 1, Name: "Krishna", Status: "Available" },
        { ID: 2, Name: "Mohan", Status: "Available" },
        { ID: 3, Name: "Raju", Status: "Busy" },
        { ID: 4, Name: "Farooq", Status: "Busy" }
      ]},
      {Region: "North", Members: [
        { ID: 1, Name: "Jacob", Status: "Available" },
        { ID: 2, Name: "Smith", Status: "Available" },
        { ID: 3, Name: "Jones", Status: "Busy" },
        { ID: 4, Name: "James", Status: "Busy" }
      ]}
    ];

  }
onProjectChange($event:any){
  if ($event.target.innerHTML == "Project A") {
    this.ProjectCost = 2113507;
    this.CurrentExpenditure = 96788;
    this.AvailableFunds = 52436;
  }
  else if($event.target.innerHTML == "Project B") {
    this.ProjectCost = 88923;
    this.CurrentExpenditure = 22450;
    this.AvailableFunds = 2640;
  }
  else if($event.target.innerHTML == "Project C") {
    this.ProjectCost = 662183;
    this.CurrentExpenditure = 7721;
    this.AvailableFunds = 9811;
  }
  else if($event.target.innerHTML == "Project D") {
    this.ProjectCost = 928431;
    this.CurrentExpenditure = 562;
    this.AvailableFunds = 883;
  }
}
}
