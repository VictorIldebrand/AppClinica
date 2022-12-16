using Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Repositories {
    public interface IAppointmentRepository {
        Task<Appointment> GetAppointmentById(int id);
        Task<Appointment> CreateAppointment(Appointment appointment);
        Task<Appointment> GetAppointmentByDate(DateTime date);
        Task UpdateAppointment(Appointment appointment);
        Task DeleteAppointment(int id);
        Task<Appointment[]> GetAppointments();
        Task<bool> CheckIfAppointmentExistsById(int Id);
    }
}
