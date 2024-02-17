using System;
using VineForceAPI.Entities;
using VineForceAPI.Repositories.IBaseRepo;

namespace VineForceAPI.Repositories
{
    public interface ICountryRepo : IBaseRepo<Country,Guid>
    {
    }
}
