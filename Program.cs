using HealthcareSystem.Models;
using HealthcareSystem.Data;
using Microsoft.EntityFrameworkCore;
using var db=new AppDbContext(); db.Database.EnsureCreated();
if(!db.Patients.Any()) { var p=new Patient{Name="Sara Ahmed",DateOfBirth=new DateTime(1998,5,20)}; var d=new Doctor{Name="Dr. Karim Nabil",Specialization="Cardiology"}; db.Appointments.Add(new Appointment{Patient=p,Doctor=d,AppointmentDate=DateTime.Today.AddDays(1).AddHours(10)}); db.SaveChanges(); }
Console.WriteLine("=== Healthcare System ===");
foreach(var a in db.Appointments.Include(x=>x.Patient).Include(x=>x.Doctor).OrderBy(x=>x.AppointmentDate)) Console.WriteLine($"Date: {a.AppointmentDate:g} | Patient: {a.Patient.Name} | Doctor: {a.Doctor.Name} ({a.Doctor.Specialization})");
Console.WriteLine("\nAppointments by doctor:");
foreach(var d in db.Doctors.Include(x=>x.Appointments).ThenInclude(x=>x.Patient)) Console.WriteLine($"{d.Name}: {string.Join(", ",d.Appointments.Select(a=>a.Patient.Name))}");
