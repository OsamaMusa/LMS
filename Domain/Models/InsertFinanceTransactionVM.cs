using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class InsertFinanceTransactionVM :BaseVM
    {
        public long? UserID { get; set; }
        public long? ReserveID { get; set; } 
        public double totalAmount { get; set; }
        public DateTime time { get; set; }
    }
}
