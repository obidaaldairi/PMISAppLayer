using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
    public interface IProjectPhaseRepository
    {
        public List<ProjectPhase> GetAllProjectPhaseManager(string projectManagerId);
        public ProjectPhase GetSingleProjectPhase(int ProjectPhaseId);

        public void UpdateProjectPhase(UpdateProjectPhaseDTO NewpphDTO);
        public void DeleteProjectPhase(int ProjectPhaseId);
        public void InsertPhase(InsertPhaseDTO phaseDTO);
        public List<int> getallprojectPhase(int ProjectId);



    }
}
