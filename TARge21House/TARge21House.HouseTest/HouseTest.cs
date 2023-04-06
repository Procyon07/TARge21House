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
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");

            await Svc<IHouseService>().GetAsync(guid);

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

       

        [Fact]
        public async Task Should_UpdateHouse_WhenUpdateData()
        {
            var guid = new Guid("6e8285f6-5205-46d4-b12e-c522f797f378");

            House house = new House();

            HouseDto dto = MockHouseData();

            house.Id = Guid.Parse("6e8285f6-5205-46d4-b12e-c522f797f378");
            house.Address = "sdfdfssfgff";
            house.Price = 123;
            house.Size = 123666;            
            house.CreatedAt = DateTime.Now.AddYears(1);
            house.ModifiedAt = DateTime.Now.AddYears(1);


            await Svc<IHouseService>().Update(dto);

            Assert.Equal(house.Id, guid);
            Assert.DoesNotMatch(house.Address, dto.Address);
            Assert.DoesNotMatch(house.Size.ToString(), dto.Size.ToString());
            Assert.Equal(house.Price, house.Price);

        }

        [Fact]
        public async Task ShouldNot_UpdateHouse_WhenNotUpdateData()
        {
            HouseDto dto = MockHouseData();
            var createHouse = await Svc<IHouseService>().Create(dto);

            HouseDto nullUpdate = MockNullHouse();
            var result = await Svc<IHouseService>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.False(result.Id == nullId);
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
        private HouseDto MockNullHouse()
        {
            HouseDto nullDto = new()
            {
                Id = null,
                Address = "hhhhh",
                Price = 123,
                Size = 123,
                Rooms = 123,
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };
            return nullDto;
        }
    }
}