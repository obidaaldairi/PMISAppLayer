using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertProjectStatusDTO
    {
        public int ProjectStatusId { get; set; }
        [Required]
        [Display(Name = "Project Status Name")]
        public string ProjectStatusName { get; set; }
    }
}
