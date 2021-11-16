using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    class Book
    {
        public int Bookid { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public int Avilable { get; set; }
        public int TotalNum { get; set; }
        public float Price { get; set; }

    }
}
