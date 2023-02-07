using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertPhaseDTO2
    {
        public int PhaseId { get; set; }
        [Required]
        [Display(Name = "Phase Name")]
        public string PhaseName { get; set; }
    }
}
