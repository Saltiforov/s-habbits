using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace S_Habbits.Data
{
    public class S_HabbitsContextFactory : IDesignTimeDbContextFactory<S_HabbitsDbContext>
    {
        public S_HabbitsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<S_HabbitsDbContext>();
            optionsBuilder.UseSqlServer("Data Source=178.54.86.113,14330;Initial Catalog=S_Habbitsdb;User ID=SA;Password=19Andrei19");
            return new S_HabbitsDbContext(optionsBuilder.Options);
            
        }
    }
}