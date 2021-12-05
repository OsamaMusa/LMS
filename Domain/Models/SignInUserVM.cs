using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class SignInUserVM :BaseVM
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
