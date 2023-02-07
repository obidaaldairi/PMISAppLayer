using Microsoft.EntityFrameworkCore;
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
    public class ProjectPhaseRepository : IProjectPhaseRepository
    {
        private readonly ApplicationDbContext context; 

        public ProjectPhaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public List<ProjectPhase> GetAllProjectPhaseManager(string projectManagerId)
        {
            return context.ProjectPhases
                .Include(x => x.Phase)
                .Include(x => x.Project).Where(x => x.Project.ProjectManagerId == projectManagerId)
                .ToList();
        }
        public ProjectPhase GetSingleProjectPhase(int ProjectPhaseId)
        {
            return context.ProjectPhases.Include(x=>x.Project)
                .SingleOrDefault(x => x.ProjectPhaseId == ProjectPhaseId);
        }
        public void UpdateProjectPhase(UpdateProjectPhaseDTO NewpphDTO)
        {
            var lProjectPhase = context.ProjectPhases
                .SingleOrDefault(x => x.ProjectPhaseId == NewpphDTO.ProjectPhaseId);
            lProjectPhase.StartDate = NewpphDTO.PhaseStartDate;
            lProjectPhase.EndDate = NewpphDTO.PhaseEndDate;
            context.SaveChanges();


        }
        public void DeleteProjectPhase(int ProjectPhaseId)
        {
            var dProjectPhase = context.ProjectPhases
                .SingleOrDefault(x => x.ProjectPhaseId == ProjectPhaseId);
            context.ProjectPhases.Remove(dProjectPhase);
            context.SaveChanges();
        }


        public void InsertPhase(InsertPhaseDTO phaseDTO)
        {

            ProjectPhase pph = new ProjectPhase();
            pph.ProjectId = phaseDTO.ProjectId;
            pph.StartDate = phaseDTO.PhaseStartDate;
            pph.EndDate = phaseDTO.PhaseEndDate;
            pph.PhaseId = phaseDTO.PhaseId;

            context.ProjectPhases.Add(pph);
            context.SaveChanges();
        }
        public List<int> getallprojectPhase(int ProjectId)
        {
            return context.ProjectPhases
              .Where(x => x.ProjectId == ProjectId).Select(x => x.PhaseId).ToList();
        }

    }
}
