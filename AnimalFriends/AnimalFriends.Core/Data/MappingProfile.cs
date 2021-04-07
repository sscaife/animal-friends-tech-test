using System;
using System.Collections.Generic;
using System.Text;
using AnimalFriends.Core.Presentation;
using AutoMapper;

namespace AnimalFriends.Core.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerModel, CustomerDto>();
        }
    }
}
