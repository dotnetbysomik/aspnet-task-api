using aspnet_task_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_task_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}
