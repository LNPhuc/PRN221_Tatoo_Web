using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Booking
    {
        public Booking()
        {
            Schedulings = new HashSet<Scheduling>();
        }

        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? ArtistId { get; set; }
        public Guid? StudioId { get; set; }
        public Guid? EquipmentId { get; set; }
        public Guid? ArtWorkId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? Status { get; set; }

        public virtual ArtWork? ArtWork { get; set; }
        public virtual Artist? Artist { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual Equipment? Equipment { get; set; }
        public virtual Studio? Studio { get; set; }
        public virtual ICollection<Scheduling> Schedulings { get; set; }
    }
}
