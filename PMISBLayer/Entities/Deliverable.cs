using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Entities
{
    public class Deliverable
    {

        public int DeliverableId { get; set; }
        public string DeliverableDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectPhaseId { get; set; }
        public ProjectPhase ProjectPhase { get; set; }
    }
}
