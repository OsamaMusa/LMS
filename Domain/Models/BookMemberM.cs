using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class BookMemberM
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime Time { get; set; }
    }
}
