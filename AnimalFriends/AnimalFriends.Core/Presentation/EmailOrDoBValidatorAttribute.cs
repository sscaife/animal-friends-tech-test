using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalFriends.Core.Presentation
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EmailOrDoBValidatorAttribute : ValidationAttribute
    {
        private string[] ToCheck { get; set; }

        public EmailOrDoBValidatorAttribute(params string[] toCheck)
        {
            this.ToCheck = toCheck;
        }

        public override bool IsValid(object value)
        {
            foreach (var property in ToCheck)
            {
                var propertyInfo = value.GetType().GetProperty(property);

                if (propertyInfo == null)
                {
                    continue;
                }

                var propertyValue = propertyInfo.GetValue(value, null);

                if (propertyValue == null)
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(propertyValue.ToString()))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
