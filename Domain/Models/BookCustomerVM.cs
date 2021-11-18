using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BookCustomerVM
    {
        public long BookId { get; set; }
        public long MemberId { get; set; }
        public DateTime Time { get; set; }
        public DateTime reserveTime { get; set; }
        public bool isReturned { get; set; }
        public DateTime returnedTime { get; set; }
    }
}
