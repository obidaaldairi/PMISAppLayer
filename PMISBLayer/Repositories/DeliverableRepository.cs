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
    public class DeliverableRepository : IDeliverableRepository
    {
        private readonly ApplicationDbContext context;

        public DeliverableRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public List<Deliverable> GetAllDeliverable(string projectManagerId)
        {
            return context.Deliverables
                .Include(c => c.ProjectPhase).ThenInclude(x => x.Project)
                .Include(x => x.ProjectPhase).ThenInclude(x => x.Phase)
                .Where(x => x.ProjectPhase.Project.ProjectManagerId == projectManagerId)
                .ToList();
        }
        public List<ProjectPhase> GetProjectPhase(string projectManagerId)
        {
            return context.ProjectPhases.Include(x => x.Project)
                .Include(x => x.Phase).Where(x => x.Project.ProjectManagerId == projectManagerId)
                .ToList();
        }

        public void InsertDeliverable(InsertDelivrableDTO delivrableDTO)
        {
            Deliverable deliv = new Deliverable();
            deliv.ProjectPhaseId = delivrableDTO.ProjectPhaseId;
            deliv.DeliverableDescription = delivrableDTO.DeliverableDescription;
            deliv.StartDate = delivrableDTO.DeliStartDate;
            deliv.EndDate = delivrableDTO.DeliEndDate;
            context.Deliverables.Add(deliv);
            context.SaveChanges();
        }
        public Deliverable EditDeliverable(int DeliverableId)
        {
            return context.Deliverables.Include(x=>x.ProjectPhase)
                .SingleOrDefault(x => x.DeliverableId == DeliverableId);

        }
        public void UpdateDeliverable(UpdateDeliverableDTO UpDelivDTO)
        {
            var lDeliverable = context.Deliverables.SingleOrDefault(x => x.DeliverableId == UpDelivDTO.DeliverableId);
            lDeliverable.DeliverableDescription = UpDelivDTO.DeliverableDescription;
            lDeliverable.StartDate = UpDelivDTO.DeliStartDate;
            lDeliverable.EndDate = UpDelivDTO.DeliEndDate;

            context.SaveChanges();

        }
        public void DeleteDeliverable(int DeliverableId)
        {
            var D = context.Deliverables.SingleOrDefault(x => x.DeliverableId == DeliverableId);
            context.Deliverables.Remove(D);
            context.SaveChanges();
        }
        public ProjectPhase GetDate(int ProjectPhaseId)
        {
            return context.ProjectPhases.SingleOrDefault(x => x.ProjectPhaseId == ProjectPhaseId);
        }

    }
}
