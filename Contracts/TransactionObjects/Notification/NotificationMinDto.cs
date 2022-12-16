
using Contracts.Dto.Appointment;
using Contracts.Dto.PatientRequest;

namespace Contracts.Dto.Notification
{
    public class NotificationMinDto
    {
        public int Id { get; set; }
        public AppointmentDto Appointment { get; set; }
        public PatientRequestDto PatientRequest { get; set; }
        public bool Read { get; set; }
        public string Message { get; set; }
    }
}
