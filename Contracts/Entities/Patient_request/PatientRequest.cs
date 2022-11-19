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
        public StatusEnum Status { get; set; }

        [Column("id_student")]
        public int IdStudent { get; set; }

        [Column("new_patient")]
        public bool NewPatient { get; set; }

        [Column("id_schedule_professor")]
        public int IdScheduleProfessor { get; set; }

        [Column("procedure")]
        public string Procedure { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("active")]
        public bool Active { get; set; }
    }
}
