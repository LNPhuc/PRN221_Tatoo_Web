using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class ArtWork
    {
        public ArtWork()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public string? Size { get; set; }
        public TimeSpan? Time { get; set; }
        public Guid? ArtistId { get; set; }

        public virtual Artist? Artist { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
