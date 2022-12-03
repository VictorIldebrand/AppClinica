using Contracts.Enums.Status;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities {
    [Table("patient_request")]
    public partial class PatientRequest
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }

        [Column("date_solicitation")]
        public DateTime DateSolicitation { get; set; }

        [Column("date_treatment")]
        public DateTime DateTreatment { get; set; }

        [Column("cancellation_reason")]
        public string CancellationReason { get; set; }

        [Column("status")]
        [Required]
        public bool Status { get; set; }

        [Column("id_student")]
        public Student Student { get; set; }

        [Column("new_patient")]
        public bool NewPatient { get; set; }

        [Column("id_schedule_professor")]
        public ScheduleProfessor ScheduleProfessor { get; set; }

        [Column("procedure")]
        public string Procedure { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
