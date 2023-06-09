using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenGarden.Entities;
using ZenGarden.Infrastructure;
using ZenGarden.Services.Dtos;
using ZenGarden.ZenGarden.Entities;

namespace ZenGarden.Services;
public interface IGardenService
{
    Task<List<GardenDTO>> GetAll();
    Task<List<GardenDTO>> OrderByArea();
    Task<GardenDTO> ExtendArea(long id, int areaUnits);
    Task<GardenDTO> ViewGarden(long id);
    Task<GardenDTO> AddPlant(long id, long plantId, long walletId);
    Task<GardenDTO> DeletePlantFromGarden(long id, long plantId);
}


public class GardenService : IGardenService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GardenService(AppDbContext dbContext, IMapper mapper)//конструктор. Сохранили значения в соответствующие поля класса
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<GardenDTO>> GetAll()
    {
        return await _dbContext.Gardens.ProjectTo<GardenDTO>(_mapper.ConfigurationProvider).ToListAsync();//вернуть список всех растений
    }

    public async Task<GardenDTO> ViewGarden(long id)
    {
        return await _dbContext.Gardens.ProjectTo<GardenDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<GardenDTO>> OrderByArea()
    {
        var sortedGarden = _dbContext.Gardens.OrderBy(p => p.Area);
        return await _dbContext.Gardens.ProjectTo<GardenDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<GardenDTO> ExtendArea(long id, int areaUnits)
    {
        var garden = await _dbContext.Gardens.FindAsync(id) ?? throw new Exception("Сад с таким id не найден");
        garden.Area += areaUnits;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<GardenDTO>(garden);
    }

    public async Task<GardenDTO> AddPlant(long id, long plantId, long walletId)
    {
        var garden = await _dbContext.Gardens.FindAsync(id) ?? throw new Exception("Сад с таким id не найден");
        var plant = await _dbContext.Plants.FindAsync(plantId) ?? throw new Exception("Растение с таким id не найдено");
        var wallet = await _dbContext.Wallets.FindAsync(walletId) ?? throw new Exception("Пользователь с таким id не найден");// не получается сделать без walletId, хотя сад и кошелек связаны через пользователя (наверное, можно как-то найти кошелек по Id сада)
        if (wallet.Balance < plant.Price)
        {
            throw new Exception("Недостаточно средств для покупки этого растения");
        }
        else
        {
            wallet.Balance = wallet.Balance - plant.Price;
            plant.GardenID = garden.Id;
            plant.Garden = garden;
        }
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<GardenDTO>(garden);
    }

    public async Task<GardenDTO> DeletePlantFromGarden(long id, long plantId)
    {
        var garden = await _dbContext.Gardens.FindAsync(id) ?? throw new Exception("Сад с таким id не найден");
        var plant = await _dbContext.Plants.FindAsync(id) ?? throw new Exception("Растение с таким id не найдено");
        plant.GardenID = null;
        plant.Garden = null;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<GardenDTO>(garden);
    }
}
