using API.Controllers;
using AutoMapper;
using Data.Repositories;
using Domain.IRepositories;
using Domain.IServices;
using Domain.Services;
using LMS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Data.Context;
using Microsoft.Extensions.Configuration;
using Moq;
using Microsoft.EntityFrameworkCore;
using Domain.Models;

namespace libraryAPI.Test
{
    public class CustomerControllerTest
    {
        CustomerController _controller;
        ICustomerService _service;
        ICustomerRepository _repo;
        private FinanceRepository financeRepository;
        IMapper _mapper;
        public CustomerControllerTest()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _mapper = mapperConfig.CreateMapper();
            var dbOption = new DbContextOptionsBuilder<LMSContext>()
                .UseSqlServer("Server=SD-LP-W10-OMUSA;Database=LMS;Trusted_Connection=True;");
            var context = new LMSContext(dbOption.Options);

            _repo = new CustomerRepository(context,_mapper);
            financeRepository = new FinanceRepository(context, _mapper);
            IUserRepository userRepository = new UserRepository(context, _mapper);
            _service = new CustomerService(_repo,userRepository);
            _controller = new CustomerController(_service);

        }
        [Fact]
        public void PostTest()
        {
            bool AllAdded = true;
            bool result;
        
                result = _controller.addCustomer(new CustomerVM() { BirthDate = DateTime.UtcNow ,address="Ramallah",fullName="Test",joinDate=DateTime.UtcNow,phone="059" }).Result;

                if (!result)
                {
                    AllAdded = false;
                }
           
            Assert.True(AllAdded);

        }
        [Fact]
        public void GetAllTest()
        {

            var result = _controller.getAllCustomers().Result;
            Assert.NotNull(result);
            Assert.IsType<List<CustomerVM>>(result);
            double min = int.MaxValue;
            foreach (CustomerVM book in result)
            {
                if (book.ID < min)
                    min = book.ID;
            }
            bool condition1 = min > 0;
            Assert.True(condition1);

        }
        [Fact]
        public void GetTest()
        {
            int testNum = 1;
            var result = _controller.getCustomer(testNum).Result;
            Assert.NotNull(result);
            Assert.IsType <CustomerVM>(result);
            bool condition1 = result.ID == testNum;
            Assert.True(condition1);
        }

        [Fact]
        public void PutTest()
        {
            int testNum = 1;
            CustomerVM customer = _controller.getCustomer(testNum).Result;
            Assert.NotNull(customer);
            Assert.IsType<CustomerVM>(customer);
            customer.fullName = "PutTest";
            var result = _controller.updateCustomer(testNum, customer);
            Assert.True(result.Result);
            var result1 = _controller.getCustomer(testNum).Result;
            Assert.NotNull(result1);
            bool condition1 = result1.ID == testNum;
            Assert.Equal("PutTest", result1.fullName);
            Assert.True(condition1);
        }
        [Fact]
        public void DeleteTest()
        {
            int testNum = 1;
            CustomerVM customer = _controller.getCustomer(testNum).Result;
            Assert.NotNull(customer);
            Assert.IsType<CustomerVM>(customer);
            
            var result = _controller.deleteCustomer(testNum);
            Assert.True(result.Result);
            var result1 = _controller.getCustomer(testNum).Result;
            Assert.Null(result1);
           
        }
    }
}
