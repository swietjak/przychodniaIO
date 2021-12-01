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
    }
}