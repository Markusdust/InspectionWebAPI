using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Inspection> Inspections { get; set; }

        public DbSet<InspectionTyp> InspectionTyps { get; set; }

        public DbSet<Status> Statuses { get; set; }
    }
}
