using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;

namespace ZenGarden.Services.Dtos
{
    public class UserDTO : IMapFrom<User>
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
    }
}
