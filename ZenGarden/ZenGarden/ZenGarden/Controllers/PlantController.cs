using Microsoft.AspNetCore.Mvc;
using ZenGarden.Services;
using ZenGarden.Services.Dtos;

namespace ZenGarden.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _service;
        public PlantController(IPlantService service)
        {
            _service = service;
        }

        [HttpGet()]// показать все растения
        public Task<List<PlantDTO>> Get()
        {
            return _service.GetAll();
        }

        [HttpPost("/create_new_plant")]
        public Task<long> CreatePlant([FromBody] CreatePlantDTO dto)
        {
            return _service.CreatePlant(dto);
        }

        [HttpGet("{id}")]
        public Task<PlantDTO> GetPlantById(long id)
        {
            return _service.GetPlantById(id);
        }

        [HttpDelete("{id}/delete")]
        public Task<long> DeletePlant(long id)
        {
            return _service.DeletePlant(id);
        }

        [HttpPatch("{id}/water")]
        public Task<PlantDTO> Water(long id)
        {
            return _service.Water(id);
        }

        [HttpGet("{id}/show_insects")]
        public Task<PlantWithInsectsDTO> ShowInsects(long id)
        {
            return _service.ShowInsects(id);
        }

    }
}