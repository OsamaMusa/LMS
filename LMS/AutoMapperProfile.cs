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
            CreateMap<BookCustomerVM, BookCustomer>().ReverseMap();
            CreateMap<reserveBookCustomerVM, BookCustomer>().ReverseMap();
            CreateMap<returnBookCustomerVM, BookCustomer>().ReverseMap();
            CreateMap<BookCustomerDetailsVM, BookCustomer>().ReverseMap();


        }
    }
}