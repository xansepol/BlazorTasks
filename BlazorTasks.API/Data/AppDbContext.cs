using BlazorTasks.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorTasks.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
