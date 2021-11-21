using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ReserveBookByCustomerVM :BaseVM
    {
        
        public long BookId { get; set; }
        public long CustomerId { get; set; }
        public DateTime reserveTime { get; set; }
        public bool isReturned { get; set; }
        public DateTime returnedTime { get; set; }

    }
}
