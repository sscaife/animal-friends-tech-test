using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalFriends.Core.Presentation
{
    public class DateOfBirthValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!DateTime.TryParse(value.ToString(), out var parsedDate))
            {
                return false;
            }

            return parsedDate.Date.AddYears(18) <= DateTime.Now.Date;
        }
    }
}
