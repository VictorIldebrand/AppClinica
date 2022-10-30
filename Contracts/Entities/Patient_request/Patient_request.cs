using Contracts.Entities.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Entities
{
    [Table("patient_request")]
    public partial class Patient_request
    {
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int id { get; set; }

        [Column("date_solicitation")]
        public DateTime dateSolicitation { get; set; }

        [Column("date_treatment")]
        public DateTime dateTreatment { get; set; }

        [Column("cancellation_reason")]
        public string cancellationReason { get; set; }

        // [Column("status")]
        // [Required]
        // public StatusEnum status { get; set; }

        [Column("id_student")]
        public int idStudent { get; set; }

        [Column("new_patient")]
        public bool newPatient { get; set; }

        [Column("id_schedule_professor")]
        public int idScheduleProfessor { get; set; }

        [Column("procedure")]
        public string procedure { get; set; }

        [Column("note")]
        public string note { get; set; }

        [Column("active")]
        public bool active { get; set; }
    }
}
