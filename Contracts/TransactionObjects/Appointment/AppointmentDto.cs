using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public TimestampAttribute DateTime { get; set; }
        public int Status { get; set; }
        public string CancellationReason { get; set; }
        public string PatientRequestId { get; set; }
        public string StudentId { get; set; }
        public string EmployeeId { get; set; }
        public string NotificationId { get; set; }
        public string PatientId { get; set; }
        public string Procedure { get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
        public bool Companion { get; set; }
        public string Location { get; set; }
    }
}
