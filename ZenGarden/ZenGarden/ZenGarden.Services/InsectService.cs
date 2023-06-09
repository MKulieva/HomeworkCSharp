using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ZenGarden.ZenGarden.Entities;
using ZenGarden.Infrastructure;
using ZenGarden.Services.Dtos;
using ZenGarden.Entities;
using System.Security.Cryptography.X509Certificates;

namespace ZenGarden.Services;

public interface IInsectService
{
    Task<List<InsectDTO>> GetAll();
    Task<long> AddInsect(CreateInsectDTO dto);
    Task<long> DeleteInsect(long id);
    Task<InsectDTO> GetInsectById(long id);
    Task<InsectDTO> SettleOnPlant(long id, long plantId);
    Task<PlantDTO> PollinatePlant(long id, long plantId);
}

public class InsectService : IInsectService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public InsectService(AppDbContext dbContext, IMapper mapper)//конструктор. Сохранили значения в соответствующие поля класса
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<InsectDTO>> GetAll()
    {
        return await _dbContext.Insects.ProjectTo<InsectDTO>(_mapper.ConfigurationProvider).ToListAsync();//вернуть список всех растений
    }

    public async Task<long> AddInsect(CreateInsectDTO dto)
    {
        var entity = _mapper.Map<Insect>(dto);
        _dbContext.Insects.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }


    public async Task<InsectDTO> GetInsectById(long id)
    {
        return await _dbContext.Insects.ProjectTo<InsectDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<long> DeleteInsect(long id)
    {
        var insectToDelete = await _dbContext.Insects.FindAsync(id) ?? throw new Exception("Насекомое с таким id не найдено");
        _dbContext.Insects.Remove(insectToDelete);
        await _dbContext.SaveChangesAsync();
        return insectToDelete.Id;
    }

    public async Task<InsectDTO> SettleOnPlant(long id, long plantId)
    {
        var insect = await _dbContext.Insects.FindAsync(id);
        var plant = await _dbContext.Plants.FindAsync(plantId);
        insect.PlantId = plant.Id;
        insect.HomePlant = plant;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<InsectDTO>(insect);

    }

    public async Task<PlantDTO> PollinatePlant(long id, long plantId)
    {
        var insect = await _dbContext.Insects.FindAsync(id);
        var plant = await _dbContext.Plants.FindAsync(plantId);
        if (plant.Status == PlantStatus.Bloom)
        {
            plant.Status = PlantStatus.Fruit;
        }
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<PlantDTO>(plant);
    }
}
