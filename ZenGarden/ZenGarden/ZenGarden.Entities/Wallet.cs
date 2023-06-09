using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.ZenGarden.Entities;

namespace ZenGarden.Entities
{
    public class Wallet
    {
        /// <summary>
        /// Идентификатор кошелька
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Количество денег в кошельке
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Id владельца
        /// </summary>
        public long UserId { get; set; }


        /// <summary>
        /// Владелец
        /// </summary>
        public User User { get; set; }

        public Wallet(long userId)
        {
            UserId = userId;
            Balance = 0;
        }
    }
}
