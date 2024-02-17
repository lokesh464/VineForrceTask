using System;
using Volo.Abp.Application.Dtos;

namespace VineForceAPI.DTOs
{
    public class StateDto : EntityDto<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public Guid CountryId { get; set; }
    }
}
