
namespace Contracts.Dto.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string AppointmentId { get; set; }
        public string PatientRequestId { get; set; }
        public bool Read { get; set; }
        public string Message { get; set; }
    }
}
