using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;
using ZenGarden.Entities;

namespace ZenGarden.Services.Dtos
{
    public class PlantWithInsectsDTO : IMapFrom<Plant>
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
        /// Название типа растения
        /// </summary>
        public PlantType Type { get; set; }

        /// <summary>
        /// Насекомые, живущие на растении
        /// </summary>
        public ICollection<InsectDTO>? Insects { get; set; }
    }
}