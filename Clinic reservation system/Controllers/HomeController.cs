using System.Diagnostics;
using System.Globalization;
using AspNetCoreGeneratedDocument;
using Clinic_reservation_system.Data;
using Clinic_reservation_system.Models;
using Clinic_reservation_system.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_reservation_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplactionDbContext _context = new();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllDoctor(DoctorWithFiltrVM doctorWithFiltrVM,int page=1)
        {


           IQueryable<Doctor> DoctorAll= _context.Doctors;
            if(doctorWithFiltrVM.Name is not null)
            {
                DoctorAll=DoctorAll.Where(e=>e.Name.Contains(doctorWithFiltrVM.Name)); 
            }
            if(doctorWithFiltrVM.Specialization is not null)
            {
                DoctorAll = DoctorAll.Where(e => e.Specialization.Contains(doctorWithFiltrVM.Specialization));
            }
            var totalpage = Math.Ceiling(DoctorAll.Count() /3.00);
            DoctorAll = DoctorAll.Skip((page-1)*3).Take(3);
            ViewBag.Totalpage = totalpage;
            ViewBag.Currentpage = page;
            var alldoctor = new AllDoctorVM()
            {
                Doctors = DoctorAll.ToList()
            };

              return View(alldoctor);
        }
        [HttpGet]
        public IActionResult CompleteAppointment([FromRoute]int id )
        {
            var SingelDoctor = _context.Doctors.FirstOrDefault(e => e.Id == id);
            var OneDoctor = new AllDoctorVM()
            {
                Doctor = SingelDoctor
            };
            return View(OneDoctor);
        }


        [HttpPost]
        public IActionResult CompleteAppointment(Reservation reservation)
        {
            reservation.Id = 0;
            _context.Add(reservation);
            _context.SaveChanges();

            return RedirectToAction(nameof(Reservations));
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var SingelDoctor = _context.Doctors.Find(id);
            var singelreservation =_context.Reservations.Find(id);
            var OneDoctor = new AllDoctorVM()
            {
                Reservations= singelreservation,
                Doctor = SingelDoctor
            };
        
            return View(OneDoctor);

        }
         [HttpPost]
        public IActionResult Edit(Reservation reservation)
        {
            _context.Update(reservation);
            _context.SaveChanges();

            return RedirectToAction(nameof(Reservations));
        }






        public IActionResult Reservations()
        {
            var AllReservations=_context.Reservations.Include(e=>e.Doctor);
            ViewBag.allReservations = AllReservations;
           // var allReservationsVM=new AllReservationsVM();
            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
