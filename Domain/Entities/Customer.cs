using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Customer :Base
    {
        public string fullName { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime joinDate { get; set; }
    }
}
