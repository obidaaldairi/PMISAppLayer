using PMISBLayer.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertPhaseDTO
    {
        public int ProjectId{ get; set; }
        [Required]
        [ProjectPhaseStartDate]
        public DateTime PhaseStartDate { get; set; }
        [Required]
        [ProjectPhaseEndDate]
        public DateTime PhaseEndDate { get; set; }
        public int PhaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
