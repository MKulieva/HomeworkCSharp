using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;
using ZenGarden.Entities;

namespace ZenGarden.Services.Dtos
{
    public class InsectDTO : IMapFrom<Insect>
    {
        /// <summary>
        /// Id насекомого
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Имя насекомого
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вид насекомого
        /// </summary>
        public InsectType Type { get; set; }

        /// <summary>
        /// Id растения, на котором живет насекомое
        /// </summary>
        public long? PlantId { get; set; }
    }
}