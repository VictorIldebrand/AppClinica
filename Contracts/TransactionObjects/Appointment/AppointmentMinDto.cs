using Contracts.Dto.Employee;
using Contracts.Dto.Patient;
using Contracts.Dto.Schedule;
using Contracts.Dto.Student;
using Contracts.Enums.Status;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.Appointment
{
    public class AppointmentMinDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public StatusEnum Status { get; set; }
        public string CancellationReason { get; set; }
        public ScheduleMinDto Schedule { get; set; }
        public PatientMinDto Patient { get; set; }
        public EmployeeMinDto Employee { get; set; }
        public StudentMinDto Student { get; set; }
        public bool NewPatient { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Duration { get; set; }
        public bool Companion { get; set; }
        public string Location { get; set; }
    }
}
