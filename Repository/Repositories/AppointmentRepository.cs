using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using Contracts.Dto.Appointment;
using Contracts.RequestHandle;
using System;
using System.Collections.Generic;

namespace Repository.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly TemplateDbContext _context;
        public AppointmentRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            var result = await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _context.Appointments.Where(a => a.id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.Where(u => u.id == id).FirstOrDefaultAsync();
            appointment.status = 0;

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public Task<List<Appointment>> GetAppointmentsByParameters(string especialidade, int professorId, int alunoId, int pacienteId, Enum status, DateTime data)
        {
            throw new NotImplementedException();
        }
    }
}
