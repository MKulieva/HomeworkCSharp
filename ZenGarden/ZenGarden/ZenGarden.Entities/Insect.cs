using System.Security.Cryptography.X509Certificates;
using ZenGarden.Entities;

namespace ZenGarden.ZenGarden.Entities;

  public class Insect
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
    /// Id растения
    /// </summary>
    public long? PlantId { get; set; }
    
    /// <summary>
    /// Растение - дом
    /// </summary>
    public Plant? HomePlant { get; set; }
  }

