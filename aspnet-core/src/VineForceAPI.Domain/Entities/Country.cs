using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace VineForceAPI.Entities
{
    public class Country : Entity<Guid>
    {
        public string? Name { get; set; }
        public virtual ICollection<State> State { get; set; }
    }
}
