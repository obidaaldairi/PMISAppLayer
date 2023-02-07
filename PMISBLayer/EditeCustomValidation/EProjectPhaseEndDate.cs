using PMISBLayer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.EditeCustomValidation
{
    class EProjectPhaseEndDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var projectphase = (UpdateProjectPhaseDTO)validationContext.ObjectInstance;
            if (projectphase.EndDate < projectphase.PhaseEndDate)
            {
                return new ValidationResult("project Phase End date Should be Lower than Project End Date");
            }
            return ValidationResult.Success;
        }
    }
}
