using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Image
    {
        public Guid Id { get; set; }
        public string? Source { get; set; }
        public string? EntityId { get; set; }
    }
}
