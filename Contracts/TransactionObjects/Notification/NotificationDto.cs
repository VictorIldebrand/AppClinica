
namespace Contracts.Dto.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int IdAppointment { get; set; }
        public int IdPatientRequest { get; set; }
        public bool Read { get; set; }
        public string Message { get; set; }
    }
}
