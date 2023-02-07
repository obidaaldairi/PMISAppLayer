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
    public class PhaseRepository : IPhaseRepository
    {
        private readonly ApplicationDbContext context;

        public PhaseRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Phase> GetAllPhases()
        {
           return context.Phases.ToList();

        }
        public void InsertPhase(InsertPhaseDTO2 phDTO)
        {
            var ph = new Phase();
            ph.PhaseName = phDTO.PhaseName;
            context.Phases.Add(ph);
            context.SaveChanges();
        }
        public Phase EditPhase(int PhaseId)
        {
            return context.Phases.SingleOrDefault(x => x.PhaseId == PhaseId);
        }
        public void UpdatePhase(UpdatePhaseDTO2 UpphDTO)
        {
            var lph = context.Phases.SingleOrDefault(x => x.PhaseId == UpphDTO.PhaseId);
            lph.PhaseName = UpphDTO.PhaseName;
            context.SaveChanges();
        }
        public void DeletePhase(int PhaseId)
        {
            var ph = context.Phases.SingleOrDefault(x => x.PhaseId == PhaseId);
            context.Phases.Remove(ph);
            context.SaveChanges();
        }
    }
}
