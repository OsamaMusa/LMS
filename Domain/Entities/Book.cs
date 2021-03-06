using Domian.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{

    public class Book:Base
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Avilable { get; set; }
        public int TotalNum { get; set; }
        public float Price { get; set; }

        [ForeignKey("Publisher")]
        public long publisherID { get; set; }
        public Publisher Publisher { get; set; }


        [ForeignKey("User")]
        public long? userID { get; set; }
        public Users User { get; set; }

    }
}
