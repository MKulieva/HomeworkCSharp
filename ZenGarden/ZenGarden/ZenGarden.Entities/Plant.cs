using System.Security.Cryptography.X509Certificates;
using ZenGarden.Entities;

namespace ZenGarden.ZenGarden.Entities
{
    /// <summary>
    /// Растения - !!! не понятно делать ли каждому растению ID или название вида как ПК, но их может быть несколько как в одном саду, так и в разных
    /// </summary>
    public class Plant
    {
        /// <summary>
        /// идентификатор растения
        /// </summary>
        public long Id { get; set; }


        /// <summary>
        /// Название растения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание растения
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Цена растения
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Статус растения
        /// </summary>
        public PlantStatus Status { get; set; } = PlantStatus.Sprout;

        /// <summary>
        /// Название типа растения
        /// </summary>
        public PlantType Type { get; set; }


        /// <summary>
        /// ID сада
        /// </summary>
        public long? GardenID { get; set; }

        /// <summary>
        /// Сад, где растет растение
        /// </summary>
        public Garden? Garden { get; set; }

        /// <summary>
        /// Насекомые, живущие на растении
        /// </summary>
        public ICollection<Insect>? Insects { get; set; }
    }
}
