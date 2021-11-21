using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Customer :Base
    {


        [Required]
        public string fullName { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime joinDate { get; set; }
    }
}
