using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
   public  class Permission:Base
    {
        public string Name { set; get; }
        public string Description { set; get; }

        [ForeignKey("role")]
        public long RoleID { set; get; }

        public Role role { set; get; }

        public IEnumerable<Users> user { set; get; }

        public IEnumerable<Customer> customer { set; get; }
    }
}
