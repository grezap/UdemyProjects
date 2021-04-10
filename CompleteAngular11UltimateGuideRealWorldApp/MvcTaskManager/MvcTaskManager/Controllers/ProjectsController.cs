using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcTaskManager.Identity;
using MvcTaskManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTaskManager.Controllers
{
    //[Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private ApplicationDbContext db;

        public ProjectsController( ApplicationDbContext applicationDbContext)
        {
            db = applicationDbContext;
        }

        [HttpGet]
        [Route("api/projects")]
        public List<Project> Get()
        {
            List<Project> projects = db.Projects.ToList();
            return projects;
        }

        [HttpGet]
        [Route("api/projects/search/{searchby}/{searchtext}")]
        public List<Project> Search(string searchBy, string searchText)
        {
            List<Project> projects = null;
            switch (searchBy)
            {
                case "ProjectID":
                    projects = db.Projects.Where(p =>p.ProjectID.ToString().Contains(searchText)).ToList();
                    break;
                case "ProjectName":
                    projects = db.Projects.Where(p => p.ProjectName.ToString().Contains(searchText)).ToList();
                    break;
                case "DateOfStart":
                    projects = db.Projects.Where(p => p.DateOfStart.ToString().Contains(searchText)).ToList();
                    break;
                case "TeamSize":
                    projects = db.Projects.Where(p => p.TeamSize.ToString().Contains(searchText)).ToList();
                    break;
                default:
                    break;
            }
            return projects;
        }

        [HttpPost]
        [Route("api/projects")]
        public Project Post([FromBody] Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return project;
        }

        [HttpPut]
        [Route("api/projects")]
        public Project Put([FromBody] Project project)
        {
            var proj = db.Projects.Where(p => p.ProjectID == project.ProjectID).SingleOrDefault();
            if (proj != null)
            {
                proj.ProjectName = project.ProjectName;
                proj.DateOfStart = project.DateOfStart;
                proj.TeamSize = project.TeamSize;
                db.SaveChanges();
                return proj;
            }
            else
            {
                return null;
            }
        }

        [HttpDelete]
        [Route("api/projects")]
        public int Delete(int ProjectID)
        {
            var proj = db.Projects.Where(p => p.ProjectID == ProjectID).SingleOrDefault();
            if (proj != null)
            {
                db.Projects.Remove(proj);
                db.SaveChanges();
                return ProjectID;
            }
            else
            {
                return -1;
            }
        }
    }
}
