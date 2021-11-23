using System;
using System.Collections.Generic;
using System.Text;
using Domian.Entities;

namespace Domain.Entities
{
    public class Publisher:Base
    {
        public string Address { set; get; }
        public string Name { set; get; }
        public string PhoneNo { set; get; }

    }
}
