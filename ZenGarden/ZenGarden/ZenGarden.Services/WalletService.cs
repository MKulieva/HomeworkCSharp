using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ZenGarden.ZenGarden.Entities;
using ZenGarden.Infrastructure;
using ZenGarden.Services.Dtos;
using ZenGarden.Entities;

namespace ZenGarden.Services;
   public interface IWalletService
   {
    Task<WalletDTO> ShowBalance(long id);
    Task<WalletDTO> BuyPlant(long id, long plantId);
    Task<WalletDTO> AddMoney(long id, int sum);
    Task<List<WalletDTO>> GetAll();

    }
    public class WalletService : IWalletService
   {
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public WalletService(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<WalletDTO>> GetAll()
    {
        return await _dbContext.Wallets.ProjectTo<WalletDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }


    public async Task<WalletDTO> ShowBalance(long id)
    {
        return await _dbContext.Wallets.ProjectTo<WalletDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task <WalletDTO> BuyPlant (long id, long plantId)// по идее этот метод не нужен, AddPlant тоже покупает растение + добавляет в сад
    {
        var wallet = await _dbContext.Wallets.FindAsync(id) ?? throw new Exception("Кошелек с таким id не найден");
        var plantToBuy = await _dbContext.Plants.FindAsync(plantId)?? throw new Exception("Растение с таким id не найдено");
        if (wallet.Balance < plantToBuy.Price)
        {
            throw new Exception("Недостаточно средств для покупки этого растения");
        }

        else
        {
            wallet.Balance = wallet.Balance - plantToBuy.Price;
        }
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<WalletDTO>(wallet);
    }

    public async Task<WalletDTO> AddMoney (long id, int sum)
    {
        var wallet = await _dbContext.Wallets.FindAsync(id) ?? throw new Exception("Кошелек с id не найден");
        wallet.Balance += sum;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<WalletDTO>(wallet);
    }

}

