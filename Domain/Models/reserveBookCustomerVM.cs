using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class reserveBookCustomerVM :BaseVM
    {
        public long BookId { get; set; }
        public long CustomerId { get; set; }
        public DateTime reserveTime { get; set; }
        public long ReserveUserID { get; set; }
    }
}
