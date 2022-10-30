using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public TimestampAttribute Date { get; set; }
        public int Status { get; set; }
        public string Cancellation_Reason { get; set; }
        public string PatientRequestId { get; set; }
        public string SubjectId { get; set; }
        public string PatientId { get; set; }
        public string Procedure { get; set; }
        public string Note { get; set; }
    }
}
