using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMISAppLayer
{
    public class InsertProjectDTO
    {
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }
        [Required]
        public decimal ContractAmount { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "Project Type is Required")]
        public int ProjectTypeId { get; set; }
        [Required(ErrorMessage = "Project Status is Required")]
        public int ProjectStatusId { get; set; }
        [Required(ErrorMessage = "Client Name is Required")]
        public int ClientId { get; set; }
        [Required]
        [Display(Name = "Contract File")]
        public IFormFile ContractFile { get; set; }

    }
}
