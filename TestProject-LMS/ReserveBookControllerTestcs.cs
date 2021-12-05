using Domain.IServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject_LMS
{
    public class ReserveBookControllerTestcs
    {
        private readonly Mock<IReserveBookByCustomerService> Mockservice;
        public ReserveBookControllerTestcs()
        {
            Mockservice =  new Mock<IReserveBookByCustomerService>();
        }

      
    }
}
