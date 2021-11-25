using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class FinanceTransactionsVM :BaseVM
    {
      
        public UserVM User { get; set; }

        public ReserveBookByCustomerDetailsVM Reserve { get; set; }
  
        public double totalAmount { get; set; }

        public DateTime time { get; set; }
    }
}
