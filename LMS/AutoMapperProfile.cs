using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace LMS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerVM>().ReverseMap();
        }

    }
}