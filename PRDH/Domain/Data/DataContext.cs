using Microsoft.EntityFrameworkCore;
using PRDH.Domain.Models;

namespace PRDH.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Case> Cases { get; set; }
}