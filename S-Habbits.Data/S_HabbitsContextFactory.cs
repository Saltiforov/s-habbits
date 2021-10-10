using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace S_Habbits.Data
{
    public class SHabbitsContextFactory : IDesignTimeDbContextFactory<SHabbitsDbContext>
    {
        public SHabbitsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SHabbitsDbContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=178.54.86.113,14330;Initial Catalog=S_Habbitsdb;User ID=SA;Password=19Andrei19");
            return new SHabbitsDbContext(optionsBuilder.Options);
        }
    }
}