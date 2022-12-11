using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Contracts.Entities;
using Contracts.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace Repository.Repositories {
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly TemplateDbContext _context;

        public AppointmentRepository(TemplateDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _context.Appointments.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            var result = await _context.Appointments.AddAsync(appointment);
            try{
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }

            return result.Entity;
        }

        public async Task<Appointment> GetAppointmentByDate(DateTime date)
        {
            return await _context.Appointments.Where(a => a.DateAndTime == date).FirstOrDefaultAsync();
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.Where(u => u.Id == id).FirstOrDefaultAsync();
            if(appointment.Status == 0){
                throw new Exception("Consulta já removida");
            }
            appointment.Status = 0;

            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<Appointment[]> GetAppointments()
        {
            return await _context.Appointments.Where(a => a.Id > 0).ToArrayAsync();
        }

        public async Task<bool> CheckIfAppointmentExistsById(int id)
        {
            var result = await _context.Appointments.AnyAsync(u => u.Id == id);
            return result;
        }
    }
}
