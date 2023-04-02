using Microsoft.EntityFrameworkCore;
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
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            await _context.Houses.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }

        public async Task<House> Delete(Guid id)
        {
            var houseId = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);            

            _context.Houses.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }

        public async Task<House> GetAsync(Guid id)
        {
            var result = await _context.Houses
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<House> Update(HouseDto dto)
        {
            var domain = new House()
            {
                Id = dto.Id,
                Address = dto.Address,
                Size = dto.Size,
                Price = dto.Price,
                Rooms = dto.Rooms,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = DateTime.Now,
            };

            _context.Houses.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
