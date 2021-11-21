using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class ReserveBookByCustomer :Base
    {
        [ForeignKey("Book")]
        public long BookId { get; set; }

        [ForeignKey("Customer")]
        public long CustomerId { get; set; }
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public DateTime reserveTime { get; set; }
        public bool isReturned { get; set; }
        public DateTime returnedTime { get; set; }

    }
}
