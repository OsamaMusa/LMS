using API.Controllers;
using Domain.IServices;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject_LMS
{
    public class ReserveBookByCustomerControllerTestcs
    {
        private readonly MockReserveBookService Mockservice;
       public ReserveBookByCustomerControllerTestcs()
        {
            Mockservice = new MockReserveBookService();
        }
        [Fact]
        public void ReserveBookByCustomerController_ReserveBook_CustomerAcessDenied()
        {
            //Arrange 
            var controller = new ReserveBookByCustomerController( Mockservice.MockingReserveBook("AD").Object);

            //Act
            var res = controller.ReserveBook(new reserveBookCustomerVM());
            var status = (IStatusCodeActionResult)res;

            //Assert;
            Assert.Equal(400, status.StatusCode);

        }

        [Fact]
        public void ReserveBookByCustomerController_ReserveBook_BookReservedOk()
        {
            //Arrange 
            var controller = new ReserveBookByCustomerController(Mockservice.MockingReserveBook("R").Object);

            //Act
            var res = controller.ReserveBook(new reserveBookCustomerVM());
            var status = (IStatusCodeActionResult)res;

            //Assert;
            Assert.Equal(200, status.StatusCode);

        }

        [Fact]
        public void ReserveBookByCustomerController_ReserveBook_BookNotFound()
        {
            //Arrange 
            var controller = new ReserveBookByCustomerController(Mockservice.MockingReserveBook("BNF").Object);

            //Act
            var res = controller.ReserveBook(new reserveBookCustomerVM());
            var status = (IStatusCodeActionResult)res;

            //Assert;
            Assert.Equal(404, status.StatusCode);

        }

        [Fact]
        public void ReserveBookByCustomerController_GetAllReservations_Ok()
        {

            //Arrange
            var controller = new ReserveBookByCustomerController(Mockservice.MockingGetAllReservations(MockingReservations()).Object);

            //Act
            var res = controller.GetAll();
            var status = (IStatusCodeActionResult)res;
            //var okResult = res as OkObjectResult;
            //var list = okResult.Value as List<ReserveBookByCustomerDetailsVM>;

            //Assert

            Assert.Equal(200, status.StatusCode);
        }
        [Fact]
        public void ReserveBookByCustomerController_GetAllReservations_NoReservations()
        {

            //Arrange
            var controller = new ReserveBookByCustomerController(Mockservice.MockingGetAllReservations_NoReservations().Object);

            //Act
            var res = controller.GetAll();
            var status = (IStatusCodeActionResult)res;
         
            //Assert
           
           Assert.Equal(400, status.StatusCode);
        }


        private List<ReserveBookByCustomerDetailsVM> MockingReservations()
        {
            return new List<ReserveBookByCustomerDetailsVM>()
            {
                new ReserveBookByCustomerDetailsVM(){ID = 1, isReturned=true, Customer= new CustomerVM() },
                new ReserveBookByCustomerDetailsVM(){ID = 2, isReturned=true, Customer= new CustomerVM() }
            };
        }

    }


 public class MockReserveBookService: Mock<IReserveBookByCustomerService>
    {
        public MockReserveBookService MockingReserveBook(string res)
        {
            Setup(x => x.reserveBookCustomer(It.IsAny<reserveBookCustomerVM>()))
               .Returns(res);

            return this;
        }

        public MockReserveBookService MockingGetAllReservations(List<ReserveBookByCustomerDetailsVM> res)
        {
            Setup(x => x.getAllBookCustomers().Result)
               .Returns(res);

            return this;
        }

        public MockReserveBookService MockingGetAllReservations_NoReservations()
        {
            Setup(x => x.getAllBookCustomers().Result)
               .Returns( (List<ReserveBookByCustomerDetailsVM>)null);

            return this;
        }
    }

}
