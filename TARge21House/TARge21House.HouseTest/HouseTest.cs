using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;
using TARge21House.Core.Domain;
using Xunit;

namespace TARge21House.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            HouseDto house = new HouseDto();

            //spaceship.Id = Guid.Parse(guid);
            house.Address = "asd";
            house.Price = 123;
            house.Size = 123;
            house.Rooms = 123;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseService>().Create(house);

            Assert.NotNull(result);
        }
    }
}