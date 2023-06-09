using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;


namespace ZenGarden.Services.Dtos;

public class GardenDTO : IMapFrom<Garden>
{
    /// <summary>
    /// ID сада
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Владелец
    /// </summary>
    public UserDTO User { get; set; }

    /// <summary>
    /// площадь сада
    /// </summary>
    public int Area { get; set; }

    /// <summary>
    /// список растений в саду
    /// </summary>
    public List<PlantDTO>? Plants {get; set; }
}
