using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public  class PermissionVM:BaseVM
    {
   
        public string Name { set; get; }
        public string Description { set; get; }
        public long? RoleID { set; get; }

       

    }
}
