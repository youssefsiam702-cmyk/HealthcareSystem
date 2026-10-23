using Microsoft.EntityFrameworkCore;
using HealthcareSystem.Models;
namespace HealthcareSystem.Data;
public class AppDbContext : DbContext {
 public DbSet<Patient> Patients => Set<Patient>(); public DbSet<Doctor> Doctors => Set<Doctor>(); public DbSet<Appointment> Appointments => Set<Appointment>();
 protected override void OnConfiguring(DbContextOptionsBuilder o) => o.UseSqlite("Data Source=healthcare.db");
 protected override void OnModelCreating(ModelBuilder m) {
  m.Entity<Appointment>().HasKey(a=>new{a.PatientId,a.DoctorId,a.AppointmentDate});
  m.Entity<Appointment>().HasOne(a=>a.Patient).WithMany(p=>p.Appointments).HasForeignKey(a=>a.PatientId);
  m.Entity<Appointment>().HasOne(a=>a.Doctor).WithMany(d=>d.Appointments).HasForeignKey(a=>a.DoctorId);
 }
}