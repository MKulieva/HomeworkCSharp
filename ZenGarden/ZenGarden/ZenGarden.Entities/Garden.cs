using System.Xml.Linq;
using ZenGarden.Entities;

namespace ZenGarden.ZenGarden.Entities
{
    /// <summary>
    /// Сад
    /// </summary>
    public class Garden
    {
        /// <summary>
        /// ID сада
        /// </summary>
        public long Id { get; set; }

        
        /// <summary>
        /// Площадь сада
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// Id владельца
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Владелец
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Растения на грядке
        /// </summary>
        public ICollection<Plant>? Plants { get; set; }

        public Garden(long userId)
        {
            UserId = userId;
            Area = 0;
        }
    }
}
