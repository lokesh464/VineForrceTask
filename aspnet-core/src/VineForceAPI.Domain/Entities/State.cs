using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace VineForceAPI.Entities
{
    public class State : Entity<Guid>
    {
        public string ?Name { get; set; }
        public Guid  CountryId { get; set; }
    }
}
