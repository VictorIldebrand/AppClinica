
namespace Contracts.Dto.Notification
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string PatientId { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
