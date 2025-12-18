using Microsoft.EntityFrameworkCore;
using HouseKitchenManager.Models;

namespace HouseKitchenManager.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Member> Members { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Rating> Ratings { get; set; }
}
