using Contracts.DTO.Appointment;
using Contracts.RequestHandle;
using Contracts.TransactionObjects.Login;
using System.Threading.Tasks;

namespace Contracts.Interfaces.Services {
    public interface IAppointmentService {
        Task<RequestResult<RequestAnswer>> CreateAppointment(AppointmentDTO registerRequest);
        Task<RequestResult<AppointmentDTO>> GetAppointmentByDate(DateTime date);
        Task<RequestResult<RequestAnswer>> UpdateAppointment(AppointmentDTO appointment);
        Task<RequestResult<RequestAnswer>> DeleteAppointment(int id);
    }
}
