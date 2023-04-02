using Microsoft.AspNetCore.Mvc;
using TARge21House.Core.Domain;
using TARge21House.Core.Dto;
using TARge21House.Core.ServiceInterface;
using TARge21House.Data;
using TARge21House.Models.House;

namespace TARge21House.Controllers
{
    public class HouseController : Controller
    {
        private TARge21HouseContext _context;
        private IHouseService _houseServices;

        public HouseController
            (
                TARge21HouseContext context,
                IHouseService houseservices
            )
        {
            _context = context;
            _houseServices = houseservices;
        }
        public IActionResult Index()
        {
            var result = _context.Houses
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new House
                {
                    Id = x.Id,
                    Address = x.Address,
                    Size = x.Size,
                    Price = x.Price,
                    Rooms = x.Rooms
                });

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            HouseCreateUpdateViewModel house = new HouseCreateUpdateViewModel();

            return View("CreateUpdate", house);
        }


        [HttpPost]
        public async Task<IActionResult> Create(HouseCreateUpdateViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Address = vm.Address,
                Size = vm.Size,
                Price = vm.Price,
                Rooms = vm.Rooms,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            }
            var result = await _houseServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
