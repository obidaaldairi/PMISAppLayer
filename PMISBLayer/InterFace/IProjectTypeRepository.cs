using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IProjectTypeRepository
    {
        public List<ProjectType> GetAllProjectType();
        public void InsertProjectType(InsertProjectTypeDTO ptDTO);
        public ProjectType EditProjectType(int ProjectTypeId);
        public void UpdateProjectType(UpdateProjectTypeDTO UptDTO);
        public void DeleteProjectType(int ProjectTypeId);




    }
}
