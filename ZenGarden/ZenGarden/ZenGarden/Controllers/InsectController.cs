using Microsoft.AspNetCore.Mvc;
using ZenGarden.Services;
using ZenGarden.Services.Dtos;

namespace ZenGarden.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsectController : ControllerBase
    {
        private readonly IInsectService _service;
        public InsectController(IInsectService service)
        {
            _service = service;
        }

        [HttpGet()]
        public Task<List<InsectDTO>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpPost("/add_insect")]
        public Task<long> AddInsect(CreateInsectDTO dto)
        {
            return _service.AddInsect(dto);
        }

        [HttpDelete("{id}/delete_insect")]
        public Task<long> DeleteInsect(long id)
        {
            return _service.DeleteInsect(id);
        }


        [HttpGet("{id}/get_by_id")]
        public Task<InsectDTO> GetInsectById(long id)
        {
            return _service.GetInsectById(id);
        }

        [HttpPatch ("{id}/settle_on_plant")]
        public Task<InsectDTO> SettleOnPlant(long id, long plantId)
        {
            return _service.SettleOnPlant(id, plantId);
        }

        [HttpPatch("{id}/pollinate_plant")]
        public Task<PlantDTO> PollinatePlant(long id, long plantId)
        {
            return _service.PollinatePlant(id, plantId);
        }
    }
}

