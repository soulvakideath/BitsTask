using BitsTask.Models;
using Microsoft.EntityFrameworkCore;

namespace BitsTask.Context;

public class CsvDbContext : DbContext
{
    public CsvDbContext(DbContextOptions<CsvDbContext> options) : base(options)
    {
    }

    public DbSet<CsvData> CsvData { get; set; }
}