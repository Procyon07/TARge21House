using TARge21House.Core.Domain;
using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;

namespace TARge21House.ApplicationServices.Services
{
    internal class HouseService : IHouseService
    {
        public Task<House> Create(HouseDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<House> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<House> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<House> Update(HouseDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
