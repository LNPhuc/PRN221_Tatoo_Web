using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Artist
    {
        public Artist()
        {
            ArtWorks = new HashSet<ArtWork>();
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? StudioId { get; set; }
        public int? Experience { get; set; }

        public virtual Studio? Studio { get; set; }
        public virtual ICollection<ArtWork> ArtWorks { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
