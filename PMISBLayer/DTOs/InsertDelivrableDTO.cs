using PMISBLayer.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertDelivrableDTO
    {
        public int ProjectPhaseId { get; set; }
        [Required]
        [Display(Name = "Deliverable Description")]
        public string DeliverableDescription { get; set; }
        [Required]
        public DateTime DeliStartDate { get; set; }
        [Required]
        public DateTime DeliEndDate { get; set; }
    }
}
