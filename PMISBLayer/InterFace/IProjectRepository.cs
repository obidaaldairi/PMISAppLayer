using PMISAppLayer;
using PMISBLayer;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Repositories
{
    public interface IProjectRepository
    {
        public List<Project> GetAllProjects();

        public void InsertProject(Project project);

        public Project GettProject(int ProjectId);

        public List<Project> GetProjectManagerProjects( string projectManagerId);
        public Project EditProject(int ProjectId);
        public void UpdeteProject(UpdateProjectDTO proDTO);
        public void DeleteProject(int ProjectId);

    }
}
