using Microsoft.EntityFrameworkCore;
using PRDH_API.Entities;

namespace PRDH_API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<LaboratoryTest> LaboratoryTests { get; set; }
    public DbSet<Case> Cases { get; set; }
}