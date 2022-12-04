using Contracts.Dto.Appointment;
using Contracts.RequestHandle;
using System;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IAppointmentService {
        Task<RequestResult<RequestAnswer>> CreateAppointment(AppointmentDto registerRequest);
        Task<RequestResult<AppointmentDto>> GetAppointmentByDate(DateTime date);
        Task<RequestResult<AppointmentDto>> GetAppointments();
        Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDto appointment, int id);
        Task<RequestResult<RequestAnswer>> DeleteAppointment(int id);
    }
}