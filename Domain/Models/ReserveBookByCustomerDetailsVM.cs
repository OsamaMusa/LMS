using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ReserveBookByCustomerDetailsVM :BaseVM
    {

        public BookM Book { get; set; }
        public CustomerVM Customer { get; set; }
        public UserVM ReservedUser { get; set; }
        public UserVM ReturnedUser { get; set; }
        public DateTime reserveTime { get; set; }
        public bool isReturned { get; set; }
        public DateTime returnedTime { get; set; }



    }
}
