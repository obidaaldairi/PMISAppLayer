using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.DTOs
{
    public class InsertProjectTypeDTO
    {
        public int ProjectTypeId { get; set; }
        [Required]
        [Display(Name = "Project Type Name")]
        public string ProjectTypeName { get; set; }
    }
}
