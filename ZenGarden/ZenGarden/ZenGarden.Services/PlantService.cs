using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ZenGarden.ZenGarden.Entities;
using ZenGarden.Infrastructure;
using ZenGarden.Services.Dtos;
using ZenGarden.Entities;

namespace ZenGarden.Services;

public interface IPlantService
{
    Task<List<PlantDTO>> GetAll();//заносим все методы класса в интерфейс
    Task<long> CreatePlant(CreatePlantDTO dto);
    Task<PlantDTO> GetPlantById(long id);
    Task<long> DeletePlant(long id);
    Task<PlantDTO> Water(long id);
    Task<PlantWithInsectsDTO> ShowInsects (long id);
}

public class PlantService : IPlantService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public PlantService(AppDbContext dbContext, IMapper mapper)//конструктор. Сохранили значения в соответствующие поля класса
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<PlantDTO>> GetAll()
    {
        return await _dbContext.Plants.ProjectTo<PlantDTO>(_mapper.ConfigurationProvider).ToListAsync();//вернуть список всех растений
    }

    public async Task<long> CreatePlant(CreatePlantDTO dto)
    {
        var plant = _mapper.Map<Plant>(dto);
        _dbContext.Plants.Add(plant);
        await _dbContext.SaveChangesAsync();

        return plant.Id;
    }


    public async Task<PlantDTO> GetPlantById(long id)
    {
        return await _dbContext.Plants.ProjectTo<PlantDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task <long> DeletePlant (long id)
    {
        var plantToDelete = await _dbContext.Plants.FindAsync(id)?? throw new Exception("Растение с таким id не найдено");
        _dbContext.Plants.Remove(plantToDelete);
        await _dbContext.SaveChangesAsync();
        return plantToDelete.Id;
    }

    public async Task <PlantDTO> Water (long id)
    {
        var plantToWater = await _dbContext.Plants.FindAsync(id);
        if (plantToWater.Status == PlantStatus.Sprout)
        {
            plantToWater.Status = PlantStatus.Young;
        }
        else if (plantToWater.Status == PlantStatus.Young)
        {
            plantToWater.Status = PlantStatus.Adult;
        }
        else if (plantToWater.Status == PlantStatus.Adult)
        {
            plantToWater.Status = PlantStatus.Bloom;
        }
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<PlantDTO>(plantToWater);
    }

    public async Task <PlantWithInsectsDTO> ShowInsects (long id)
    {
        return await _dbContext.Plants.ProjectTo<PlantWithInsectsDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

}

