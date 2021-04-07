using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFriends.Core.Presentation
{
    public class CustomerModel
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
