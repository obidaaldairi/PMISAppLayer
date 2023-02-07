using PMISBLayer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.EditeCustomValidation
{
    class EProjectPhaseStartDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var projectphase = (UpdateProjectPhaseDTO)validationContext.ObjectInstance;
            if (projectphase.StartDate > projectphase.PhaseStartDate)
            {
                return new ValidationResult("project Phase start date Should be greater than Project start Date");
            }
            return ValidationResult.Success;
        }
    }
}
