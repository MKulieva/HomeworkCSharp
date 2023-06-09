using ZenGarden.Entities;

namespace ZenGarden.ZenGarden.Entities
{/// <summary>
/// Пользователи 
/// </summary>
    public class User
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
        /// Пароль
        /// </summary>
        public string Password { get; set; }


        /// <summary>
        /// Сад
        /// </summary>
        public Garden Garden { get; set; }

        /// <summary>
        /// Кошелек пользователя
        /// </summary>
        public Wallet Wallet { get; set; }
    }
}
