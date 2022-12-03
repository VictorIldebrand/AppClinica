using Contracts.Entities.Attributes;
using Microsoft.EntityFrameworkCore;
using Contracts.Entities;
using Repository.Utills;

namespace Repository.Context
{
    public class TemplateDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        //public DbSet<PatientOrder> PatientOrders { get; set; }
        public DbSet<PatientRequest> PatientRequests { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<ScheduleProfessor> ScheduleProfessors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.PropertyInfo != null)
                    {
                        var attributes = property
                        .PropertyInfo
                        .GetCustomAttributes(typeof(SensitiveDataAttribute), false);

                        if (attributes.Length > 0)
                        {
                            property.SetValueConverter(new DataProtectionConverter());
                        }
                    }
                }
            }
        }
    }
}
