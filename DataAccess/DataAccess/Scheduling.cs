using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Scheduling
    {
        public Guid Id { get; set; }
        public Guid? BookingId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string? Status { get; set; }

        public virtual Booking? Booking { get; set; }
    }
}
