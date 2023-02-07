using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IProjectStatusRepository
    {
        public List<ProjectStatus> GetAllProjectStatuses();
        public void InsertProjectStatus(InsertProjectStatusDTO proSDTO);
        public ProjectStatus EditProjectStatus(int ProjectStatusId);
        public void UpdateProjectStatus(UpdateProjectStatusDTO UpsDTO);
        public void DeleteProjectStatus(int ProjectStatusId);



    }
}
