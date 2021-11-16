using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domian.Entities
{
    public class Base
    {
        [Key]
        public long ID { get; set; } 
    }
}
