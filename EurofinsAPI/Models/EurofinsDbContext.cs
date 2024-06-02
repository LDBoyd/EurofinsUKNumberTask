using Microsoft.EntityFrameworkCore;

namespace EurofinsAPI.Models
{
    public class EurofinsDbContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }

        public EurofinsDbContext(DbContextOptions<EurofinsDbContext> options)
            : base(options)
        {

        }
    }
}