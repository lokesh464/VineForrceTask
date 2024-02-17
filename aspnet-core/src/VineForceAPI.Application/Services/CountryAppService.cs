using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VineForceAPI.DTOs;
using VineForceAPI.Entities;
using VineForceAPI.Entities.Manager;
using VineForceAPI.Interfaces.IAppServices;
using VineForceAPI.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace VineForceAPI.Services
{
    [AllowAnonymous]
    public class CountryAppService : CrudAppService<
        Country,
        CountryDto,
        Guid,
        CountryPagedAndSortedResultRequestDto,
        CreateUpdateCountryDto>, ICountryAppService

    {
        private readonly ICountryRepo _countryRepo;
        private readonly CountryManager _countryManager;

        public CountryAppService(ICountryRepo countryRepo, CountryManager countryManager) : base(countryRepo)
        {
            _countryRepo = countryRepo;
            _countryManager = countryManager;
        }
        public override async Task<CountryDto> CreateAsync(CreateUpdateCountryDto input)
        {
            Country country1 = ObjectMapper.Map<CreateUpdateCountryDto, Country>(input);
            Country country = await _countryRepo.InsertAsync(country1);
            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        public override async Task<PagedResultDto<CountryDto>> GetListAsync(CountryPagedAndSortedResultRequestDto input)
        {
            Expression<Func<Country, bool>> predicate = s => true;

            if (!string.IsNullOrWhiteSpace(input.Filter))
            {
                predicate = predicate.And(x => x.Name.Contains(input.Filter));
            }

            long count = await _countryRepo.GetCountAsync(predicate);

            List<Country> executer = await _countryRepo.GetPagedListAsync(predicate, input.SkipCount, input.MaxResultCount, input.Sorting, includeDetails: true, default, x => x.State);

            List<CountryDto> countryDtos = ObjectMapper.Map<List<Country>, List<CountryDto>>(executer.ToList());

            return new PagedResultDto<CountryDto> { Items = countryDtos, TotalCount = count };
        }

        public override async Task<CountryDto> UpdateAsync(Guid id, CreateUpdateCountryDto input)
        {
            Country country = await _countryRepo.GetAsync(id);
            if (country != null && !string.IsNullOrEmpty(input.Name))
            {
                await _countryManager.UpdateAsync(country, input.Name.Trim());
                var updatedEntity = await _countryRepo.UpdateAsync(country, true);

                return ObjectMapper.Map<Country, CountryDto>(updatedEntity);
            }
            return new CountryDto() { Name = null };
        }

        protected override Task DeleteByIdAsync(Guid id)
        {
            return base.DeleteByIdAsync(id);
        }
    }
}
