using System;
using System.Collections.Generic;
using System.Text;
using VineForceAPI.Interfaces.Common;
using Volo.Abp.Application.Dtos;

namespace VineForceAPI.DTOs
{
    public class CountryPagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto, IFilteredResultRequest
    {
        public string? Filter { get; set; }
    }
}
