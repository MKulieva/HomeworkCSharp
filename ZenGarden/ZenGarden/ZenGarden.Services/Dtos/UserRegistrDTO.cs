using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Services.Mapper;
using ZenGarden.ZenGarden.Entities;


namespace ZenGarden.Services.Dtos
{
    public class UserRegistrDTO : IMapTo<User>
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }

    }
}
