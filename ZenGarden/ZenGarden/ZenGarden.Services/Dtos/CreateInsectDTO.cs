using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;
using ZenGarden.Entities;

namespace ZenGarden.Services.Dtos
{
    public class CreateInsectDTO : IMapTo<Insect>
    {

        /// <summary>
        /// Имя насекомого
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Вид насекомого
        /// </summary>
        public InsectType Type { get; set; }

    }
}
