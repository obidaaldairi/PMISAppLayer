using PMISBLayer.DTOs;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.InterFace
{
   public interface IDeliverableRepository
    {
        public List<Deliverable> GetAllDeliverable(string projectManagerId);

        public List<ProjectPhase> GetProjectPhase(string projectManagerId);
        public void InsertDeliverable(InsertDelivrableDTO delivrableDTO);
        public Deliverable EditDeliverable(int DeliverableId);
        public void UpdateDeliverable(UpdateDeliverableDTO UpDelivDTO);
        public void DeleteDeliverable(int DeliverableId);
        public ProjectPhase GetDate(int ProjectPhaseId);





    }
}
