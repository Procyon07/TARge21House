using TARge21House.Core.Domain;
using TARge21House.Core.Dto;

namespace TARge21House.Core.ServiceInterface
{
    public interface IHouseService
    {
        Task<House> Create(HouseDto dto);

    }
}
