using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotesAndDutiesAPI.Models;

namespace NotesAndDutiesAPI;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<DutyModel> duties { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DutyModel>()
                    .Property(t => t.Status)
                    .HasConversion(new EnumToStringConverter<DutyStatus>());
        
        modelBuilder.Entity<DutyModel>()
                    .HasOne<UserModel>().WithMany()
                    .HasForeignKey(d => d.Author)
                    .HasPrincipalKey(u => u.Username);
    }

    public DbSet<UserModel> users { get; set; }
}