using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Oracle.ManagedDataAccess.Client;
using RolesAndEntityFramework.Roles;


namespace RolesAndEntityFramework.Database;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.LogTo(Console.WriteLine);
        
        var xx = new OracleConnectionStringBuilder
        {
            DataSource = "127.0.0.1/ORCLPDB1",
            UserID = "system",
            Password = "atlantis",
            Pooling = true,
            MaxPoolSize = 100,
            MinPoolSize = 10
        };
        var connectionstring = xx.ToString();
            
        optionsBuilder.UseOracle(connectionstring);
        
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("INTERFACE");
        
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}