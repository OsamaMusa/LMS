using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace LMS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<CustomerVM, Customer>().ReverseMap();

            CreateMap<BookM, Book>().ReverseMap();
           
            CreateMap<ReserveBookByCustomerVM, ReserveBookByCustomer>().ReverseMap();
            
            CreateMap<reserveBookCustomerVM, ReserveBookByCustomer>().ReverseMap();
            
            CreateMap<returnBookCustomerVM, ReserveBookByCustomer>().ReverseMap();
            
            CreateMap<ReserveBookByCustomerDetailsVM, ReserveBookByCustomer>().ReverseMap();
            CreateMap<PublisherVM, Publisher>().ReverseMap();


        }
    }
}