﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BookCustomerDetailsVM :BaseVM
    {

        public BookM Book { get; set; }
        public CustomerVM Customer { get; set; }
        public DateTime reserveTime { get; set; }
        public bool isReturned { get; set; }
        public DateTime returnedTime { get; set; }
    }
}
