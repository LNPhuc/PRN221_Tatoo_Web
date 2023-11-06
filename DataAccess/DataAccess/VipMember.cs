using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class VipMember
    {
        public Guid Id { get; set; }
        public Guid? CustomerId { get; set; }
        public Guid? StudioId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Studio? Studio { get; set; }
    }
}
