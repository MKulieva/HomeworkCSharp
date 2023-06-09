using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;
using ZenGarden.Entities;

namespace ZenGarden.Services.Dtos
{
    public class PlantDTO : IMapFrom<Plant>
    {
        /// <summary>
        /// ID растения
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
    }
}
