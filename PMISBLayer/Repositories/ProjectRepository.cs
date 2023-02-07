using Microsoft.EntityFrameworkCore;
using PMISAppLayer;
using PMISBLayer.Data;
using PMISBLayer;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace PMISBLayer.Repositories
{
    public class ProjectRepository : IProjectRepository 
    {
        private readonly ApplicationDbContext context; 

        public ProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Project> GetAllProjects()
        {
            return context.Projects.Include(x => x.ProjectType).ToList();
        }

        public Project GettProject(int ProjectId)
        {
            return context.Projects.SingleOrDefault(x => x.ProjectId == ProjectId);
        }
        public void InsertProject(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
        }

        public List<Project> GetProjectManagerProjects(string projectManagerId)
        {
            return context.Projects.Include(p => p.ProjectStatus)
                .Include(s => s.ProjectType)
                .Include(c=>c.Client)
                .Where(x => x.ProjectManagerId == projectManagerId).ToList();
        }

        public Project EditProject(int ProjectId)
        {
            return context.Projects.SingleOrDefault(x => x.ProjectId == ProjectId);
        }

        public void UpdeteProject(UpdateProjectDTO proDTO)
        {
            var lproject = context.Projects.SingleOrDefault(x => x.ProjectId == proDTO.ProjectId);
            lproject.ProjectName = proDTO.ProjectName;
            lproject.ProjectStatusId = proDTO.ProjectStatusId;
            lproject.ProjectTypeId = proDTO.ProjectTypeId;
            lproject.ClientId = proDTO.ClientId;
            lproject.StartDate = proDTO.StartDate;
            lproject.EndDate = proDTO.EndDate;
            lproject.ContractAmount = proDTO.ContractAmount;

           
            context.SaveChanges();
        }
        public void DeleteProject(int ProjectId)
        {
            var p =context.Projects.SingleOrDefault(x => x.ProjectId == ProjectId);
            context.Projects.Remove(p);
            context.SaveChanges();

        }

    }
}
