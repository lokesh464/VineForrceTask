using System;
using VineForceAPI.DTOs;
using Volo.Abp.Application.Services;

namespace VineForceAPI.Interfaces.IAppServices
{
    public interface IStateAppService : ICrudAppService<StateDto,Guid,StatePagedAndSortedResultRequestDto,CreateUpdateStateDto>
    {
    }
}
