# HealthcareSystem

## Open and run
1. Open `HealthcareSystem.sln` in Visual Studio.
2. Allow NuGet restore to complete.
3. Press `Ctrl+F5`.

Requires the .NET 10 SDK and a Visual Studio version that supports .NET 10. The project uses SQLite and creates its local database automatically on first run.

## Relationships
Patient ↔ Doctor is many-to-many through Appointment. Appointment uses (PatientId, DoctorId, AppointmentDate) as a composite key, allowing multiple appointments at different times.

See `Database-Diagram.png` for the relationship diagram.
