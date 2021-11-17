using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    class BookCustomer
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }

        [Key, Column(Order = 2)]
        public int MemberId { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public DateTime reserveTime { get; set; }
        public bool isReturned { get; set; }
        public DateTime returnedTime { get; set; }

    }
}
