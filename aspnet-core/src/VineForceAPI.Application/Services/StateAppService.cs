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

namespace VineForceAPI.Services
{
    public class StateAppService : CrudAppService<State, StateDto, Guid, StatePagedAndSortedResultRequestDto, CreateUpdateStateDto>, IStateAppService
    {
        private readonly IStateRepo _stateRepo;
        private readonly StateManager _stateManager;
        public StateAppService(IStateRepo stateRepo, StateManager stateManager) : base(stateRepo)
        {
            _stateRepo = stateRepo;
            _stateManager = stateManager;
        }


        public override async Task<StateDto> CreateAsync(CreateUpdateStateDto input)
        {
            var state = ObjectMapper.Map<CreateUpdateStateDto, State>(input);
            var stateEntity = await _stateRepo.InsertAsync(state);

            return new StateDto() { Id = stateEntity.Id, Name = stateEntity.Name };
        }

        public override async Task<PagedResultDto<StateDto>> GetListAsync(StatePagedAndSortedResultRequestDto input)
        {
            Expression<Func<State, bool>> predicate = s => true;

            if (!string.IsNullOrWhiteSpace(input.Filter))
            {
                predicate = predicate.And(x => x.Name.Contains(input.Filter));
            }

            long count = await _stateRepo.GetCountAsync(predicate);

            List<State> executer = await _stateRepo.GetPagedListAsync(predicate, input.SkipCount, input.MaxResultCount, input.Sorting, includeDetails: false);

            List<StateDto> stateDtos = ObjectMapper.Map<List<State>, List<StateDto>>(executer.ToList());

            return new PagedResultDto<StateDto> { Items = stateDtos, TotalCount = count };
        }


        public override async Task<StateDto> UpdateAsync(Guid id, CreateUpdateStateDto input)
        {
            State state = await _stateRepo.GetAsync(id);
            if (state != null && !string.IsNullOrEmpty(input.Name))
            {
                await _stateManager.UpdateAsync(state, input.Name.Trim());
                var updatedEntity = await _stateRepo.UpdateAsync(state, true);
                return ObjectMapper.Map<State, StateDto>(updatedEntity);
            }
            return new StateDto() { Name = null};
        }


        protected override Task DeleteByIdAsync(Guid id)
        {
            return base.DeleteByIdAsync(id);
        }

    }
}
