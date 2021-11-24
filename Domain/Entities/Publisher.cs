using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Domian.Entities;

namespace Domain.Entities
{
    public class Publisher:Base
    {
        public string Adress { set; get; }
        public string Name { set; get; }
        public string PhoneNo { set; get; }
        public IEnumerable<Book> Books { get; set; }
        [ForeignKey("User")]
        public long? userID { get; set; }
        public Users User { get; set; }
    }
}
