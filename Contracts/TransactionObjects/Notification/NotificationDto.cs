
namespace Contracts.Dto.Notification
{
    public class NotificationDto
    {
        public int AppointmentId { get; set; }
        public int PatientRequestId { get; set; }
        public bool Read { get; set; }
        public string Message { get; set; }
    }
}
