using Microsoft.EntityFrameworkCore;

namespace PatientManagement.Model
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                        .Property(patient => patient.Id)
                        .ValueGeneratedOnAdd();

        }

        public DbSet<Patient> Patients { get; set; }
    }
}
