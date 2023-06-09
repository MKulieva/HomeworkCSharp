using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;
using ZenGarden.Entities;

namespace ZenGarden.Services.Dtos
{
    public class UserDetailDTO : IMapFrom<User>
    {
        /// <summary>
        /// ID пользователя
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Сад
        /// </summary>
        public GardenDTO Garden { get; set; }


        /// <summary>
        /// Кошелек пользователя
        /// </summary>
        public WalletDTO Wallet { get; set; }

    }
}
