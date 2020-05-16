using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GoCebuTravelAndToursMVC.Common
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute() 
            : base(typeof(DateTime), DateTime.Now.ToShortDateString(), "12/31/2020")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var inputYear = value as int?;
            var result = (inputYear != null && inputYear >= 1886 && inputYear <= DateTime.Now.Year);

            return result ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
        }

        private string GetErrorMessage()
        {
            return "The year must be greater than 1886 and lower than the actual year.";
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(GetErrorMessage(), name);
        }
    }
}