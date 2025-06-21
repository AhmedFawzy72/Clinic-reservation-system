namespace Clinic_reservation_system.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
    }
}
