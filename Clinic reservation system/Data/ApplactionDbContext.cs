using Clinic_reservation_system.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic_reservation_system.Data
{
    public class ApplactionDbContext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;database=Reservation Doctor2;" +
                "Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
        }
    }
}
