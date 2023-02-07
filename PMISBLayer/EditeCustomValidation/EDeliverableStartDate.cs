using PMISBLayer.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMISBLayer.EditeCustomValidation
{
    class EDeliverableStartDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var projectphase = (UpdateDeliverableDTO)validationContext.ObjectInstance;
            if (projectphase.StartDate > projectphase.DeliStartDate)
            {
                return new ValidationResult("project Phase start date Should be greater than Project start Date");
            }
            return ValidationResult.Success;
        }
    }
}
