using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class FinanceTransactions :Base
    {
        [ForeignKey("User")]
        public long? UserID { get; set; }
        public Users User { get; set; }

        [ForeignKey("Reserve")]
        public long? ReserveID { get; set; }
        public ReserveBookByCustomer Reserve { get; set; }
        [Required]
        public double totalAmount { get; set; }
        [Required]
        public DateTime time { get; set; }
    }
}
