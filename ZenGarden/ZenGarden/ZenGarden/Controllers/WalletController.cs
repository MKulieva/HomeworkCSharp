using Microsoft.AspNetCore.Mvc;
using ZenGarden.Services;
using ZenGarden.Services.Dtos;

namespace ZenGarden.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _service;
        public WalletController(IWalletService service)
        {
            _service = service;
        }

        [HttpGet()]
        public Task<List<WalletDTO>> Get()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}/show_balance")]
        public Task<WalletDTO> ShowBalance(long id)
        {
            return _service.ShowBalance(id);
        }

        [HttpPatch("{id}/buy_plant")]
        public Task<WalletDTO> BuyPlant(long id, long plantId)
        {
            return _service.BuyPlant(id, plantId);
        }

        [HttpPatch("{id}/add_money")]
        public Task<WalletDTO> AddMoney(long id, int sum)
        {
            return _service.AddMoney(id, sum);
        }
    }
}