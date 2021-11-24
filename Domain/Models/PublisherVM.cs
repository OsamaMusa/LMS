using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class PublisherVM:BaseVM
    {
        public string Adress { set; get; }
        public string Name { set; get; }
        public string PhoneNo { set; get; }
        public IEnumerable<BookM> Books { get; set; }
        public long userID { get; set; }

    }
}
