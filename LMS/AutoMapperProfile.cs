using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace LMS
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerVM, Customer>();
            CreateMap<Customer, CustomerVM>();
            CreateMap<Book, BookM>();
            CreateMap<BookM, Book>();
        }
    }
}