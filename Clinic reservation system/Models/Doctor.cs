namespace Clinic_reservation_system.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }
        public string? Img { get; set; }
        public ICollection<Reservation>? Reservations {  get; set; }
    }
}
