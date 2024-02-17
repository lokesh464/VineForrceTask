using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace VineForceAPI.Entities.Manager
{
    public class StateManager : DomainService
    {
        public async Task UpdateAsync(State state, string name) => state.Name = name;
    }
}
