using Clinic_reservation_system.Models;
namespace Clinic_reservation_system.ViewModel
{
    public class AllDoctorVM
    {

        public List<Doctor> Doctors { get; set; } = null!;
        public Doctor Doctor { get; set; }=null!;
        public Reservation ?Reservations { get; set; }
        

    }
}
