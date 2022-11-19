using Contracts.Dto.Appointment;
using Contracts.RequestHandle;
using System;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IAppointmentService {
        Task<RequestResult<AppointmentDto>> CreateAppointment(AppointmentDto registerRequest);
        Task<RequestResult<AppointmentDto>> GetAppointmentByDate(DateTime date);
        Task<RequestResult<AppointmentDto>> GetAppointments();
        Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDto appointment);
        Task<RequestResult<RequestAnswer>> DeleteAppointment(int id);
    }
}