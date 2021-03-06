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
    public class ReserveBookTest
    {
        ReserveBookByCustomerController _controller;
        IReserveBookByCustomerService _service;
        IReserveBookByCustomerRepository _repo;
        IBookRepository bookRepository;
        ICustomerRepository customerRepository;
        private FinanceRepository financeRepository;
        IMapper _mapper;

        public ReserveBookTest()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _mapper = mapperConfig.CreateMapper();
            var dbOption = new DbContextOptionsBuilder<LMSContext>()
                .UseSqlServer("Server=SD-LP-W10-OMUSA;Database=LMS;Trusted_Connection=True;");
            var context = new LMSContext(dbOption.Options);

            _repo = new ReserveBookByCustomerRepository(context, _mapper);
            bookRepository = new BookRepository(context, _mapper);
            customerRepository = new CustomerRepository(context, _mapper);
            financeRepository = new FinanceRepository(context, _mapper);
            UserRepository userRepository = new UserRepository(context, _mapper);
            _service = new ReserveBookByCustomerService(_repo,bookRepository,customerRepository,financeRepository,userRepository);
            _controller = new ReserveBookByCustomerController(_service);

        }

        [Fact]
        public void ReserveTest()
        {
/*            bool AllAdded = true;
            bool result;
            int available = bookRepository.getBookByID(1).Result.Avilable;
            result = _controller.ReserveBook(new reserveBookCustomerVM() { BookId = 1, CustomerId = 1, reserveTime = DateTime.UtcNow }).Result;

            if (!result && bookRepository.getBookByID(1).Result.Avilable != available-1 )
            {
                AllAdded = false;
            }

            Assert.True(AllAdded);
*/
        }

        [Fact]
        public void ReturnTest()
        {
/*            bool AllAdded = true;
            bool result;
            int available = bookRepository.getBookByID(1).Result.Avilable;
            result = _controller.ReturnBook(new returnBookCustomerVM() {ID=1, BookId = 1, CustomerId = 1, isReturned =true ,returnedTime = DateTime.UtcNow }).Result;
            if (!result && bookRepository.getBookByID(1).Result.Avilable != available + 1)
            {
                AllAdded = false;
            }

            Assert.True(AllAdded);*/

        }

        [Fact]
        public void GetAllReservationsTest()
        {
/*
            var result = _controller.GetAll().Result;
            Assert.NotNull(result);
            Assert.IsType<List<ReserveBookByCustomerDetailsVM>>(result);
            double min = int.MaxValue;
            foreach (ReserveBookByCustomerDetailsVM bookReserve in result)
            {
                if (bookReserve.ID < min)
                    min = bookReserve.ID;
            }
            bool condition1 = min > 0;
            Assert.True(condition1);*/

        }

        [Fact]
        public void GetReserveTest()
        {
/*            int testNum = 1;
            var result = _controller.getReservationsByID(testNum).Result;
            Assert.NotNull(result);
            Assert.IsType<ReserveBookByCustomerDetailsVM>(result);
            bool condition1 = result.ID == testNum;
            Assert.True(condition1);*/
        }

       
    }
}
