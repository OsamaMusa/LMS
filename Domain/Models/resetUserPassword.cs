using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ResetUserPassword :BaseVM
    {
        public string newPassword { get; set; }
        public string oldPassword { get; set; }
    }
}
