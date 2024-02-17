using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace VineForceAPI.Entities.Manager
{
    public class CountryManager : DomainService
    {
        public async Task UpdateAsync(Country country, string name) => country.Name = name;
    }
}
