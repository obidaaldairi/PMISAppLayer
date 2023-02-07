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
    
    public class ProjectTypeRepository : IProjectTypeRepository
    {
        private readonly ApplicationDbContext context;

        public ProjectTypeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<ProjectType> GetAllProjectType()
        {
            return context.ProjectTypes.ToList();
        }
        public void InsertProjectType(InsertProjectTypeDTO ptDTO)
        {
            var t = new ProjectType();
            t.ProjectTypeName = ptDTO.ProjectTypeName;
            context.ProjectTypes.Add(t);
            context.SaveChanges();
        }
        public ProjectType EditProjectType(int ProjectTypeId)
        {
            return context.ProjectTypes.SingleOrDefault(x => x.ProjectTypeId == ProjectTypeId);
        }
        public void UpdateProjectType(UpdateProjectTypeDTO UptDTO)
        {
            var lpt = context.ProjectTypes.SingleOrDefault(x => x.ProjectTypeId == UptDTO.ProjectTypeId);
            lpt.ProjectTypeName = UptDTO.ProjectTypeName;
            context.SaveChanges();
        }
        public void DeleteProjectType(int ProjectTypeId)
        {
            var t = context.ProjectTypes.SingleOrDefault(x => x.ProjectTypeId == ProjectTypeId);
            context.ProjectTypes.Remove(t);
            context.SaveChanges();
        }
    }
}
