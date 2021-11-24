using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    internal class PublishedBookByPublisher
    {
        [ForeignKey("Publisher")]
        public long PublisherID { get; set; }

        [ForeignKey("Book")]
        public long BookID { get; set; }

        public DateTime PublishedYear { get; set; }
        public int EditionNo { get; set; }
    }
}
