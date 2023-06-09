using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using ZenGarden.Entities;
using ZenGarden.ZenGarden.Entities;

namespace ZenGarden.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)//сюда будем прокидывать строку подключения
    {
      
    }

    /// <summary>
    /// Добавила таблицы, соответствующие классам, в БД
    /// </summary>
    public DbSet<User> Users { get; set; }
    public DbSet<Garden> Gardens { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Wallet> Wallets { get; set; }
    public DbSet<Insect> Insects { get; set; }

  
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
    
    
}