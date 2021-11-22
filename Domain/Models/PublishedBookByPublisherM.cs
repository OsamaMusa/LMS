using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    class PublishedBookByPublisherM:BaseVM
    {

        public long PublisherID { get; set; }
        public long BookID { get; set; }

        public DateTime PublishedYear { get; set; }
        public int EditionNo { get; set; }
    }
}
