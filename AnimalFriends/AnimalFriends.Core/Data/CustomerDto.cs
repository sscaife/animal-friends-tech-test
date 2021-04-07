using System;

namespace AnimalFriends.Core.Data
{
    public class CustomerDto
    {
        public int? Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string PolicyReferenceNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
    }
}
