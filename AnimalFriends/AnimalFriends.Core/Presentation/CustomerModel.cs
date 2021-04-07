using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AnimalFriends.Core.Presentation
{
    [EmailOrDoBValidator(new []{ "Email", "DateOfBirth" }, ErrorMessage = "Please provide a value for Email, DoB or both")]
    public class CustomerModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Firstname { get; set; }
        
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Surname { get; set; }
        
        [RegularExpression("^[A-Z]{2}\\-[0-9]{6}$", ErrorMessage = "Policy reference number should be in the format XX-000000, where XX can be any 2 capital letters followed by hyphen and 6 digits")]
        public string PolicyReferenceNumber { get; set; }
        
        [DateOfBirthValidation(ErrorMessage = "The customer is not over 18")]
        public DateTime? DateOfBirth { get; set; }
        
        [RegularExpression("^[A-Za-z]{4,}@[A-Za-z]{2,}(\\.com|\\.co\\.uk)$", ErrorMessage = "The email must begin with at least 2 characters before the @ and end in .com or .co.uk")]
        public string Email { get; set; }
    }
}
