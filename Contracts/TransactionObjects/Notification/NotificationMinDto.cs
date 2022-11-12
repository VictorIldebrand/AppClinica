
namespace Contracts.Dto.Notification
{
    public class NotificationMinDto
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string PatientId { get; set; }
        public int Read { get; set; }
        public string Message { get; set; }
    }
}
