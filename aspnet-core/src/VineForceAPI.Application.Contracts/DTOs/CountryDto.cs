using System;
using System.Collections;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace VineForceAPI.DTOs
{
    public class CountryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public ICollection<StateDto>  State { get; set; }
    }
}
