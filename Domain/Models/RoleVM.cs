using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class RoleVM:BaseVM
    {

        public string Name { set; get; }
        public string Description { set; get; }

        //public IEnumerable<Permission> permission { set; get; }

        //public IEnumerable<AppUsers> user { set; get; }
    }
}
