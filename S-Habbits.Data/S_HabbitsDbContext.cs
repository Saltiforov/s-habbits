using Microsoft.EntityFrameworkCore;
using S_Habbits.Data.Models;

namespace S_Habbits.Data
{
    public class SHabbitsDbContext : DbContext
    {
        public SHabbitsDbContext(DbContextOptions<SHabbitsDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<Habbit> Habbits { get; set; }
        public DbSet<HabbitEvent> HabbitEvents { get; set; }
    }
}