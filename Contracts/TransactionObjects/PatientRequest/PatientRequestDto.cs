using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Dto.PatientRequest
{
    public class PatientRequestDto
    {
        public int Id { get; set; }
        public DateTime DataSolicitation { get; set; }
        public DateTime DataTreatment { get; set; }
        public bool Status { get; set; }
        public int IdStudent { get; set; }
        public bool NewPatient { get; set; }
        public int IdScheduleProfessor { get; set; }
        public string Procedure { get; set; }
        public string Note { get; set; }
    }
}
