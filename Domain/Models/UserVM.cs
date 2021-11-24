using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class UserVM :BaseVM
    {
       
        public string fullName { get; set; }
       
        public string phone { get; set; }
        
        public string department { get; set; }
     
        public string address { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
