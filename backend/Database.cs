using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;

namespace Backend.Context
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options)
            : base(options)
        {

        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<WorkingTime> WorkingTimes { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
    }
}