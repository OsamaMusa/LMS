using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    class BookMember
    {
        [Key, Column(Order = 1)]
        public int BookId { get; set; }
        [Key, Column(Order = 2)]
        public int MemberId { get; set; }
        public Book Book { get; set; }
        public BookMember Member { get; set; }
        public DateTime Time { get; set; }
    }
}
