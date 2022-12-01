using Contracts.Enums.Status;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.Appointment
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public StatusEnum Status{ get; set; }
        public string CancellationReason { get; set; }
        public int IdSchedule { get; set; }
        public int IdPatient { get; set; }
        public int IdEmployee { get; set; }
        public int IdStudent { get; set; }
        public bool NewPatient { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Duration { get; set; }
        public bool Companion { get; set; }
        public string Location { get; set; }
    }
}
