using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Users : Base
    {


        [Required]
        public string username { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string department { get; set; }
        [Required]
        public string address { get; set; }
        public DateTime BirthDate { get; set; }

        [ForeignKey("permission")]
        public long? roleID { set; get; }
        public Role role { set; get; }
        public string password { get; set; }


    }
}
