using System;
using VineForceAPI.DTOs;
using Volo.Abp.Application.Services;

namespace VineForceAPI.Interfaces.IAppServices
{
    public interface ICountryAppService : ICrudAppService<
        CountryDto,
        Guid,
        CountryPagedAndSortedResultRequestDto,
        CreateUpdateCountryDto>
    {
    }
}
