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
    public class BookControllerTest
    {
        BookController _controller;
        IBookS _service;
        IBookR _repo;
        IMapper _mapper;
        public BookControllerTest()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            _mapper = mapperConfig.CreateMapper();
            var dbOption = new DbContextOptionsBuilder<LMSContext>()
     .UseSqlServer("Server=SD-LP-W10-OMUSA;Database=LMS;Trusted_Connection=True;");
            var context = new LMSContext(dbOption.Options);
            _repo = new BookR(context, _mapper);
            _service = new BookS(_repo,_mapper);
            _controller = new BookController(_service);

        }
        [Fact]
        public void PostTest()
        {
            bool AllAdded = true;
            bool result;
            for (int i = 0; i < 10; i++)
            {
                result = _controller.Post(new BookM() { Title = "book" + i, Author = "yazan", Avilable = 1, TotalNum = 1 });

                if (!result)
                {
                    AllAdded = false;
                }
            }
            Assert.True(AllAdded);

        }
        [Fact]
        public void GetAllTest()
        {
          
            var result = _controller.GetAll();
            Assert.NotNull(result);
            Assert.IsType<List<BookM>>(result);
            double max = int.MinValue;
            double min = int.MaxValue;
            foreach(BookM book in result)
            {
                if (book.ID > max)
                    max = book.ID;
                if (book.ID < min)
                    min = book.ID;
            }
            bool condition1 = max > 0;
            bool condition2 = min > 0;
            Assert.True(condition1);
            Assert.True(condition2);
            
        }
        [Fact]
        public void GetTest()
        {
            int testNum = 1;
            var result = _controller.Get(testNum);
            Assert.NotNull(result);
            Assert.IsType<BookM>(result);
            bool condition1 = result.ID==testNum;
            Assert.True(condition1);

        }
        [Fact]
        public void GetAvilableTest()
        {
            var result = _controller.GetAll();
            Assert.NotNull(result);
            Assert.IsType<List<BookM>>(result);
            double max = int.MinValue;
            double min = int.MaxValue;
            foreach (BookM book in result)
            {
                if (book.ID > max)
                    max = book.ID;
                if (book.ID < min)
                    min = book.ID;
            }
            bool condition1 = max > 0;
            bool condition2 = min > 0;
            Assert.True(condition1);
            Assert.True(condition2);
        }
        [Fact]
        public void PutTest()
        {
            int testNum = 1;
            BookM book = _controller.Get(testNum);
            Assert.NotNull(book);
            Assert.IsType<BookM>(book);
            book.Title = "PutTest";
            var result = _controller.Put(book);
            Assert.True(result);
            var result1 = _controller.Get(testNum);
            Assert.NotNull(result1);
            bool condition1 = result1.ID == testNum;
            Assert.Equal("PutTest", result1.Title);
            Assert.True(condition1);
        }
    }
}
