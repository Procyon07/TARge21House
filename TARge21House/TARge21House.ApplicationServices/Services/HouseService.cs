using TARge21House.Core.Domain;
using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;
using TARge21House.Data;

namespace TARge21House.ApplicationServices.Services
{
    public class HouseService : IHouseService
    {
        private readonly TARge21HouseContext _context;

        public HouseService
            (
                TARge21HouseContext context
            )
        {
            _context = context;
        }
        public async Task<House> Create(HouseDto dto)
        {
            House house = new House();

            house.Id = Guid.NewGuid();
            house.Address = dto.Address;
            house.Size = dto.Size;
            house.Price = dto.Price;
            house.Rooms = dto.Rooms;
            house.CreatedAt = dto.CreatedAt;
            house.ModifiedAt = dto.ModifiedAt;

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
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
