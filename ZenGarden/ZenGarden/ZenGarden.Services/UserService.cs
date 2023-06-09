using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ZenGarden.ZenGarden.Entities;
using ZenGarden.Infrastructure;
using ZenGarden.Services.Dtos;
using ZenGarden.Entities;

namespace ZenGarden.Services;

public interface IUserService
{
    Task<List<UserDTO>> GetAll();
    Task<long> UserRegistrate(UserRegistrDTO dto);
    Task<UserDTO> GetUserById(long id);
    Task<UserDTO> ChangeName(long id, string name);
    Task<long> DeleteUser(long id);
    Task<UserDetailDTO> GetUserAllInformation(long id);
}

public class UserService : IUserService
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public UserService(AppDbContext dbContext, IMapper mapper)//конструктор. Сохранили значения в соответствующие поля класса
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<UserDTO>> GetAll()
    {
        return await _dbContext.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).ToListAsync();//вернуть юзеров, спроецировать их в юзерДТО
    }

    public async Task<long> UserRegistrate(UserRegistrDTO dto)
    {
        var user = _mapper.Map<User>(dto);
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        Garden garden = new Garden(user.Id);
        _dbContext.Gardens.Add(garden);
        Wallet wallet = new Wallet(user.Id);
        _dbContext.Wallets.Add(wallet);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task<UserDTO> GetUserById(long id)
    { 
        return await _dbContext.Users.ProjectTo<UserDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserDetailDTO> GetUserAllInformation(long id)
    {
        return await _dbContext.Users.ProjectTo<UserDetailDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<UserDTO> ChangeName(long id, string name)
    {
        var user = await _dbContext.Users.FindAsync(id) ?? throw new Exception("Пользователь с таким id не найден");
        user.Name = name;
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<long> DeleteUser(long id)
    {
        var userToDelete = await _dbContext.Users.FindAsync(id) ?? throw new Exception("Пользователь с таким id не найден");
        var wallet = userToDelete.Wallet;
        var garden = userToDelete.Garden;
        _dbContext.Users.Remove(userToDelete);
        _dbContext.Wallets.Remove(wallet);
        _dbContext.Gardens.Remove(garden);
        await _dbContext.SaveChangesAsync();
        return userToDelete.Id;
    }
}