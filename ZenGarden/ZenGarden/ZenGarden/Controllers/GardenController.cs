using Microsoft.AspNetCore.Mvc;
using ZenGarden.Services;
using ZenGarden.Services.Dtos;

namespace ZenGarden.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GardenController : ControllerBase
    {
        private readonly IGardenService _service;
        public GardenController(IGardenService service)
        {
            _service = service;
        }

        [HttpGet()]// показать все сады
        public Task<List<GardenDTO>> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}/view_garden")]
        public Task<GardenDTO> ViewGarden(long id)
        {
            return _service.ViewGarden(id);       
        }

        [HttpGet("/order_by_area")]
        public Task<List<GardenDTO>> OrderByArea()
        {
            return _service.OrderByArea();
        }

        [HttpPatch("{id}/extend_garden_area")]
        public Task<GardenDTO> ExtendArea(long id, int areaUnits)
        {
            return _service.ExtendArea(id, areaUnits);
        }

        [HttpPatch("{id}/add_plant")]
        public Task<GardenDTO> AddPlant(long id, long plantId, long walletId)
        {
            return _service.AddPlant(id, plantId, walletId);
        }

        [HttpDelete("{id}/delete_plant")]
        public Task<GardenDTO> DeletePlantFromGarden(long id, long plantId)
        {
            return _service.DeletePlantFromGarden(id, plantId);
        }


    }
}


