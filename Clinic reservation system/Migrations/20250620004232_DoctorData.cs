using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic_reservation_system.Migrations
{
    /// <inheritdoc />
    public partial class DoctorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Doctors (Name, Specialization, Img) VALUES " +
                " ('Dr. John Smith', 'Cardiology', 'doctor1.jpg')," +
                "('Dr. Sarah Johnson', 'Pediatrics', 'doctor2.jpg')," +
                "('Dr. Emily Davis', 'Dermatology', 'doctor3.jpg')," +
                "('Dr. Michael Lee', 'Orthopedics', 'doctor4.jpg')," +
                "('Dr. William Clark', 'Neurology', 'doctor5.jpg')," +
                "('Dr. Linda Taylor', 'Ophthalmology', 'doctor6.jpg')," +
                "('Dr. Robert Brown', 'ENT', 'doctor7.jpg')," +
                "('Dr. Jessica Wilson', 'Psychiatry', 'doctor8.jpg')," +
                "('Dr. David Martinez', 'Urology', 'doctor9.jpg')," +
                "('Dr. Karen Thomas', 'Gastroenterology', 'doctor10.jpg')," +
                "('Dr. James Garcia', 'Oncology', 'doctor11.jpg')," +
                "('Dr. Amanda White', 'General Medicine', 'doctor12.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE Doctors");
        }
    }
}
