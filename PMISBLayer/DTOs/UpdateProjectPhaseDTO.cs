using PMISBLayer.EditeCustomValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.DTOs
{
   public class UpdateProjectPhaseDTO
    {
        public int ProjectPhaseId { get; set; }
        public int ProjectId { get; set; }
        [EProjectPhaseStartDate]
        public DateTime PhaseStartDate { get; set; }
        [EProjectPhaseEndDate]
        public DateTime PhaseEndDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
