using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.PatientRequest
{
    public class PatientRequestDto
    {
        public int Id { get; set; }
        public DateTime DataSolicitation { get; set; }
        public TimestampAttribute DataTreatment { get; set; }
        public int Status { get; set; }
        public string StudentId { get; set; }
        public int NewPatient { get; set; }
        public string Procedure { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
    }
}
