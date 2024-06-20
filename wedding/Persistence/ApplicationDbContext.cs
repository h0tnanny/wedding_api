using Microsoft.EntityFrameworkCore;
using Wedding.API.Persistence.Models;

namespace Wedding.API.Persistence;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : DbContext(options)
{
    public DbSet<WelcomeEntity> WelcomeEntities { get; set; } = null!;
    public DbSet<GuestForm> GuestForms { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WelcomeEntity>()
            .HasKey(x => x.Id);
        
        modelBuilder.Entity<WelcomeEntity>()
            .HasIndex(x => x.Key);
        
        modelBuilder.Entity<GuestForm>()
            .HasKey(x => x.Id);
    }
}