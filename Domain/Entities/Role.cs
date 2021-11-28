using Domian.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Role:Base
    {
        public string Name { set; get; }
        public string Description { set; get; }

       public  IEnumerable<Permission> permission { set; get; }

        public IEnumerable<Users> user { set; get; }

    }
}
