using VineForceAPI.Interfaces.Common;
using Volo.Abp.Application.Dtos;

namespace VineForceAPI.DTOs
{
    public class StatePagedAndSortedResultRequestDto : PagedAndSortedResultRequestDto, IFilteredResultRequest
    {
        public string Filter { get; set; } = string.Empty;
    }
}
