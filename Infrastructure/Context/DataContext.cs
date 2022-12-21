using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class DataContext:DbContext
{
      public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
     public DbSet<Employee> Employees { get; set; }
}
