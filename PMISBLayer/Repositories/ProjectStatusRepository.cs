using PMISBLayer.Data;
using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using PMISBLayer.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMISBLayer.Repositories
{
    public class ProjectStatusRepository : IProjectStatusRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectStatusRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ProjectStatus> GetAllProjectStatuses()
        {
            return context.ProjectStatuses.ToList();
        }
        public void InsertProjectStatus(InsertProjectStatusDTO proSDTO)
        {
            var s = new ProjectStatus();
            s.ProjectStatusName = proSDTO.ProjectStatusName;
            context.ProjectStatuses.Add(s);
            context.SaveChanges();
        }
        public ProjectStatus EditProjectStatus(int ProjectStatusId)
        {
            return context.ProjectStatuses.SingleOrDefault(x => x.ProjectStatusId == ProjectStatusId);

        }
        public void UpdateProjectStatus(UpdateProjectStatusDTO UpsDTO)
        {
            var lps = context.ProjectStatuses.SingleOrDefault(x => x.ProjectStatusId == UpsDTO.ProjectStatusId);
            lps.ProjectStatusName = UpsDTO.ProjectStatusName;
            context.SaveChanges();
        }
        public void DeleteProjectStatus(int ProjectStatusId)
        {
            var s = context.ProjectStatuses.SingleOrDefault(x => x.ProjectStatusId == ProjectStatusId);
            context.ProjectStatuses.Remove(s);
            context.SaveChanges();
        }

    }
}
