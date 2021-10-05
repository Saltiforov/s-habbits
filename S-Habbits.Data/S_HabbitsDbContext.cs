using Microsoft.EntityFrameworkCore;

namespace S_Habbits.Data
{
    public class S_HabbitsDbContext : DbContext
    {
        public S_HabbitsDbContext(DbContextOptions<S_HabbitsDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<Habbit> Habbits { get; set; }
        public DbSet<HabbitEvent> HabbitEvents { get; set; }
    }
}