using Microsoft.AspNetCore.Mvc;
using ZenGarden.Services;
using ZenGarden.Services.Dtos;

namespace ZenGarden.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet()]// показать всех пользователей
        public Task<List<UserDTO>> Get()
        {
            return _service.GetAll();
        }

        [HttpPost("/register_user")]// зарегистрировать нового пользователя
        public Task<long> UserRegistrate([FromBody] UserRegistrDTO dto)
        {
            return _service.UserRegistrate(dto);
        }

        [HttpGet("{id}/get_by_id")]
        public Task<UserDTO> GetUserById(long id)
        {
            return _service.GetUserById(id);
        }

        [HttpGet("{id}/get_all_info")]
        public Task<UserDetailDTO> GetUserAllInformation(long id)
        {
            return _service.GetUserAllInformation(id);
        }

        [HttpPatch("{id}/change_name")]
        public Task<UserDTO> ChangeName(long id, string name)
        {
            return _service.ChangeName(id, name);
        }

        [HttpDelete("{id}/delete")]
        public Task<long> DeleteUser(long id)
        {
            return _service.DeleteUser(id);
        }

}
}