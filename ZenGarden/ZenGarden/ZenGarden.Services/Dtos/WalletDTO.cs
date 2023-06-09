using ZenGarden.ZenGarden.Entities;
using ZenGarden.Services.Mapper;
using ZenGarden.Entities;


namespace ZenGarden.Services.Dtos;

   public class WalletDTO : IMapFrom<Wallet>
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
    /// Владелец
    /// </summary>
    public UserDTO User { get; set; }

}

