using System;
using System.Collections.Generic;

namespace DataAccess.DataAccess
{
    public partial class Image
    {
        public Image(Guid id, string? source, string? entityId)
        {
            Id = id;
            Source = source;
            EntityId = entityId;
        }

        public Guid Id { get; set; }
        public string? Source { get; set; }
        public string? EntityId { get; set; }
    }
}
