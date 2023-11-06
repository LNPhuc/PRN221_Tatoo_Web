using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Discount
    {
        public Guid Id { get; set; }
        public Guid? StudioId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }

        public virtual Studio? Studio { get; set; }
    }
}
