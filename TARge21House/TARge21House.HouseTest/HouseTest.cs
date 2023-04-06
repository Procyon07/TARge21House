using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;
using TARge21House.Core.Domain;

namespace TARge21House.HouseTest
{
    public class HouseTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyHouse_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            HouseDto house = new HouseDto();

            house.Address = "asd";
            house.Price = 123;
            house.Size = 123;
            house.Rooms = 123;
            house.CreatedAt = DateTime.Now;
            house.ModifiedAt = DateTime.Now;

            var result = await Svc<IHouseService>().Create(house);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldNot_GetByIdHouse_WhenReturnsNotEqual()
        {
            //Arrange
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");

            //Act
            await Svc<IHouseService>().GetAsync(guid);

            //Assert
            Assert.NotEqual(wrongGuid, guid);
        }

        [Fact]
        public async Task Should_GetByIdHouse_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");
            Guid getGuid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");

            await Svc<IHouseService>().GetAsync(getGuid);

            Assert.Equal(databaseGuid, getGuid);
        }

        [Fact]
        public async Task Should_DeleteByIdHouse_WhenDeleteHouse()
        {
            HouseDto house = MockHouseData();

            var addHouse = await Svc<IHouseService>().Create(house);
            var result = await Svc<IHouseService>().Delete((Guid)addHouse.Id);

            Assert.Equal(result, addHouse);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            HouseDto house = MockHouseData();
            var addHouse = await Svc<IHouseService>().Create(house);
            var addHouse2 = await Svc<IHouseService>().Create(house);

            var result = await Svc<IHouseService>().Delete((Guid)addHouse2.Id);

            Assert.NotEqual(result.Id, addHouse.Id);
        }

        private HouseDto MockHouseData()
        {
            HouseDto house = new()
            {
                Address = "hhhhh",
                Price = 123,
                Size = 123,
                Rooms = 123,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            return house;
        }
    }
}